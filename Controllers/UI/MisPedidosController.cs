using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proyecto_ecommerce_deportivo_net.Data;
using proyecto_ecommerce_deportivo_net.Models;

/*LIBRERIAS PARA LA PAGINACION DE LISTAR PRODUCTOS */
using X.PagedList;

/*LIBRERIAS PARA SUBR IMAGENES */
using Firebase.Auth;
using Firebase.Storage;
using System.Web.WebPages;

/*LIBRERIAS NECESARIAS PARA EXPORTAR */
using DinkToPdf;
using DinkToPdf.Contracts;
using OfficeOpenXml;
using System.IO;
using System.Linq;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;

using proyecto_ecommerce_deportivo_net.Models.Entity;
using Microsoft.AspNetCore.Identity;

using System.Drawing;

namespace proyecto_ecommerce_deportivo_net.Controllers.UI
{

    public class MisPedidosController : Controller
    {
        private readonly ILogger<MisPedidosController> _logger;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        // Objeto para la exportación
        private readonly IConverter _converter;
        public MisPedidosController(ILogger<MisPedidosController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IConverter converter)
        {
            _logger = logger;

            _userManager = userManager;
            _context = context;

            ModelState.Clear();


            _converter = converter; // PARA EXPORTAR
        }

        public async Task<IActionResult> MisPedidos(int? page)
        {
            var userId = _userManager.GetUserName(User); //sesion

            if (userId == null)
            {
                // no se ha logueado
                TempData["MessageLOGUEARSE"] = "Por favor debe loguearse antes de agregar un producto";
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                int pageNumber = (page ?? 1); // Si no se especifica la página, asume la página 1
                int pageSize = 10; // Máximo 10 pedidos por página

                pageNumber = Math.Max(pageNumber, 1); // Con esto se asegura de que pageNumber nunca sea menor que 1

                var pedidosDelCliente = _context.DataPedido.Where(p => p.UserID == userId);

                // Aquí aplicamos la paginación.
                var listaPaginada = await pedidosDelCliente.ToPagedListAsync(pageNumber, pageSize);

                return View("MisPedidos", listaPaginada);
            }
        }

        /* metodos para exportar en pdf y excel desde aqui para abajo */
        public IActionResult ExportarPedidosEnPDF()
{
    try
    {
        var userId = _userManager.GetUserName(User); // sesión

        if (userId == null)
        {
            // No se ha logueado
            TempData["MessageLOGUEARSE"] = "Por favor debe loguearse antes de exportar";
            return View("~/Views/Home/Index.cshtml");
        }
        else
        {
            // 1) Filtrar por el ID del usuario logueado
            var pedidos = _context.DataPedido
                .Where(p => p.UserID == userId)
                .ToList();

            // 2) Construir el HTML del PDF
            var html = @"
            <html>
                <head>
                    <meta charset='UTF-8'>
                    <style>
                        table {
                            width: 100%;
                            border-collapse: collapse;
                        }
                        th, td {
                            border: 1px solid black;
                            padding: 8px;
                            text-align: left;
                        }
                        th {
                            background-color: #f2f2f2;
                        }
                        img.logo {
                            position: absolute;
                            top: 0;
                            right: 0;
                            border-radius: 50%;
                            height: 3.3rem;
                            width: 3.3rem;
                        }
                        h1 {
                            color: #40E0D0; /* Color celeste */
                        }
                    </style>
                </head>
                <body>
                    <img src='https://firebasestorage.googleapis.com/v0/b/proyectos-cb445.appspot.com/o/img_logo_athletix.png?alt=media&token=a32e429b-4ece-45d2-bf00-85a8f9081a9c'
                         alt='Logo' width='100' class='logo'/>
                    <h1>Reporte de Pedidos</h1>
                    <table>
                        <tr>
                            <th>ID</th>
                            <th>UserID</th>
                            <th>Total (en soles)</th>
                            <th>Status</th>
                        </tr>";

            foreach (var pedido in pedidos)
            {
                html += $@"
                        <tr>
                            <td>{pedido.ID}</td>
                            <td>{pedido.UserID}</td>
                            <td>{pedido.Total}</td>
                            <td>{pedido.Status}</td>
                        </tr>";
            }

            html += @"
                    </table>
                </body>
            </html>";

            // 3) Configurar DinkToPdf
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4
            };
            var objectSettings = new ObjectSettings
            {
                HtmlContent = html
            };

            var pdfDoc = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            // 4) Convertir a PDF en memoria
            var file = _converter.Convert(pdfDoc);

            // 5) Asignar mensaje para consola del navegador
            TempData["MessageDeRespuesta"] = "El PDF de pedidos se generó correctamente. Iniciando descarga...";

            // 6) Devolver el PDF directamente al cliente
            return File(file, "application/pdf", "MisPedidos.pdf");
        }
    }
    catch (Exception ex)
    {
        // Loguear el error para obtener más detalles
        _logger.LogError(ex, "Error al exportar Pedidos a PDF");

        // Retornar un mensaje de error al usuario
        return StatusCode(500, "Ocurrió un error al exportar los Pedidos a PDF. Por favor, inténtelo de nuevo más tarde.");
    }
}



        public IActionResult ExportarPedidosEnExcel()
        {
            try
            {
                var userId = _userManager.GetUserName(User); // Obtener el ID del usuario logueado, el email

                if (userId == null)
                {
                    // No se ha logueado
                    TempData["MessageLOGUEARSE"] = "Por favor debe loguearse antes de exportar";
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    var resultados = (from p in _context.DataPedido
                                      where p.UserID == userId  // Filtrar por el ID del usuario logueado en este caso el id es el email
                                      join d in _context.DataDetallePedido on p.ID equals d.pedido.ID
                                      join pa in _context.DataPago on p.pago.Id equals pa.Id
                                      select new
                                      {
                                          IDPedido = p.ID,
                                          UserID = p.UserID,
                                          Total = p.Total,
                                          Status = p.Status,
                                          FechaDePago = pa.PaymentDate,
                                          NombreTarjeta = pa.NombreTarjeta,
                                          //Ultimos4DigitosTarjeta = pa.NumeroTarjeta.Length > 4 ? pa.NumeroTarjeta.Substring(pa.NumeroTarjeta.Length - 4) : pa.NumeroTarjeta,
                                          DigitosTarjeta = pa.NumeroTarjeta,
                                          MontoPagado = pa.MontoTotal,
                                          IDProducto = d.Producto.id,
                                          Cantidad = d.Cantidad,
                                          PrecioUnitario = d.Precio
                                      }).ToList();

                    using var package = new ExcelPackage();
                    var worksheet = package.Workbook.Worksheets.Add("Pedidos");

                    // Agregando un título arriba de la tabla
                    worksheet.Cells[1, 1].Value = "Reporte de Pedidos";
                    worksheet.Cells[1, 1].Style.Font.Size = 20;
                    worksheet.Cells[1, 1].Style.Font.Bold = true;

                    // Cargar los datos en la fila 3 para dejar espacio para el título de Reporte de Pedidos
                    worksheet.Cells[3, 1].LoadFromCollection(resultados, true);

                    // Dar formato a la tabla Reporte de Pedidos
                    var dataRange = worksheet.Cells[2, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
                    var table = worksheet.Tables.Add(dataRange, "Pedidos");
                    table.ShowHeader = true;
                    table.TableStyle = TableStyles.Light6;

                    // Estilo para los encabezados de las columnas 
                    worksheet.Cells[3, 1, 3, worksheet.Dimension.End.Column].Style.Font.Bold = true;
                    worksheet.Cells[3, 1, 3, worksheet.Dimension.End.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[3, 1, 3, worksheet.Dimension.End.Column].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                    worksheet.Cells[3, 1, 3, worksheet.Dimension.End.Column].Style.Font.Color.SetColor(System.Drawing.Color.DarkBlue);

                    // Ajustar el ancho de las columnas automáticamente
                    worksheet.Cells.AutoFitColumns();

                    var stream = new MemoryStream();
                    package.SaveAs(stream);

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MisPedidos.xlsx");
                }

            }
            catch (Exception ex)
            {
                // Loguear el error para obtener más detalles
                _logger.LogError(ex, "Error al exportar pedidos a Excel");
                // Retornar un mensaje de error al usuario
                return StatusCode(500, "Ocurrió un error al exportar los pedidos a Excel. Por favor, inténtelo de nuevo más tarde.");
            }
        }



        /* Para exportar individualmente los Pedidos en pdf */
        public async Task<ActionResult> ExportarUnSoloPedidoEnPDF(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound($"El pedido con ID {id} no fue encontrado, por eso no se puede exportar en PDF.");
                }

                Pedido? pedido = await _context.DataPedido.FindAsync(id);

                if (pedido == null)
                {
                    return NotFound($"El pedido con ID {id} no fue encontrado, por eso no se puede exportar en PDF.");
                }

                // Obtener la información del cliente - color al del excel --- background-color: #87CEFA ---------- background-color: 40E0D0;
                ApplicationUser? cliente = await _context.Users.FirstOrDefaultAsync(u => u.UserName == pedido.UserID);

                if (cliente == null)
                {
                    return NotFound($"El cliente con ID {pedido.UserID} no fue encontrado en la tabla de Clientes.");
                }

                var detalles = (from detalle in _context.DataDetallePedido
                                join producto in _context.Producto on detalle.Producto.id equals producto.id
                                where detalle.pedido.ID == pedido.ID
                                select new
                                {
                                    Cantidad = detalle.Cantidad,
                                    PrecioUnitario = detalle.Precio,
                                    NombreProducto = producto.Nombre,
                                    DescripcionProducto = producto.Descripcion,
                                    Importe = detalle.Cantidad * detalle.Precio
                                }).ToList();

                var html = $@"
                    <html>
                        <head>
                            <meta charset='UTF-8'>
                            <style>
                                body {{
                                    font-family: 'Arial', sans-serif;
                                    margin: 40px;
                                }}
                                header {{
                                    display: flex;
                                    justify-content: space-between;
                                    align-items: center;
                                    border-bottom: 2px solid #87CEFA;
                                    padding-bottom: 20px;
                                    margin-bottom: 40px;
                                }}
                                header img.logo {{
                                    height: 80px;
                                    width: auto;
                                }}
                                header .company-details {{
                                    text-align: right;
                                }}
                                .client-info {{
                                    background-color: #f2f2f2;
                                    padding: 10px;
                                    margin-bottom: 20px;
                                    border-radius: 5px;
                                }}
                                .invoice-details {{
                                    margin-bottom: 40px;
                                }}
                                table {{
                                    width: 100%;
                                    border-collapse: collapse;
                                }}
                                th, td {{
                                    border: 1px solid black;
                                    padding: 8px;
                                    text-align: left;
                                }}
                                th {{
                                    background-color: #f2f2f2;
                                }}
                                .total {{
                                    text-align: right;
                                    margin-top: 30px;
                                }}
                                .footer {{
                                    margin-top: 50px;
                                    font-size: 12px;
                                    color: #888;
                                }}

                                .highlighted {{
                        
                                    background-color: #87CEFA;
                                    color: black;
                                    font-weight: bold;
                                    border: 1px solid #87CEFA;
                                }}
                                
                            </style>
                        </head>
                        <body>
                            <header>
                                <img src='https://firebasestorage.googleapis.com/v0/b/proyectos-cb445.appspot.com/o/img_logo_athletix.png?alt=media&token=a32e429b-4ece-45d2-bf00-85a8f9081a9c&_gl=1*14iryjj*_ga*MTcyOTkyMjIwMS4xNjk2NDU2NzU2*_ga_CW55HF8NVT*MTY5ODAxNDc6Mi4yLjEuMTY5ODAxNDg0Ny40OC4wLjA.' alt='Logo' class='logo'/>
                                <div class='company-details'>
                                    <strong>AthletiX</strong><br>
                                    La Molina, Av. la Fontana 1250, Lima 15024<br>
                                    Teléfono: +51 927572267<br>
                                    Email: jesus_soria@usmp.pe
                                </div>
                            </header>
                            <div class='client-info'>
                                <strong>Información del Cliente:</strong><br>
                                <strong>Nombre:</strong> {cliente.Nombres} {cliente.Apellidos}<br>
                                <strong>Email:</strong> {cliente.Email}<br>
                            </div>
                            <div class='invoice-details'>
                                <strong>Factura N°: {id}</strong><br>
                                Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}<br>
                                <strong>Estado del Pedido:</strong> {pedido.Status}
                            </div>
                            <table>
                                <tr>
                                    <th>Producto</th>
                                    <th>Descripción</th>
                                    <th>Cantidad</th>
                                    <th>Precio Unitario (S/)</th>
                                    <th>Importe (S/)</th>
                                </tr>";

                                    foreach (var detalle in detalles)
                                    {
                                        html += $@"
                                        <tr>
                                            <td>{detalle.NombreProducto}</td>
                                            <td>{detalle.DescripcionProducto}</td>
                                            <td>{detalle.Cantidad}</td>
                                            <td>S/ {detalle.PrecioUnitario}</td>
                                            <td>S/ {detalle.Importe}</td>
                                        </tr>";
                                    }

                                    double subtotal = detalles.Sum(d => d.Importe);
                                    double impuesto = 0; // Aquí puedes calcular el impuesto si lo tienes.
                                    double descuento = 0; // Aquí puedes calcular el descuento si lo tienes.
                                    double total = subtotal + impuesto - descuento;

                                    html += $@"
                                    <tr>
                                        <td colspan='4' style='text-align:right;'><strong>Subtotal:</strong></td>
                                        <td>S/ {subtotal}</td>
                                    </tr>
                                    <tr>
                                        <td colspan='4' style='text-align:right;'><strong>Impuesto:</strong></td>
                                        <td>S/ {impuesto}</td>
                                    </tr>
                                    <tr>
                                        <td colspan='4' style='text-align:right;'><strong>Descuento:</strong></td>
                                        <td>S/ {descuento}</td>
                                    </tr>
                                    <tr class='highlighted'>
                                        <td colspan='4' style='text-align:right;'><strong>Total:</strong></td>
                                        <td >S/ {total}</td>
                                    </tr>
                            </table>
                            <div class='footer'>
                                Gracias por su compra.
                            </div>
                        </body>
                    </html>";

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                };
                var objectSettings = new ObjectSettings
                {
                    HtmlContent = html
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var file = _converter.Convert(pdf);
                return File(file, "application/pdf", $"Pedido_{id}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al exportar el pedido {id} a PDF");
                return StatusCode(500, $"Ocurrió un error al exportar el pedido {id} a PDF. Por favor, inténtelo de nuevo más tarde.");
            }
        }

        /* Para exportar individualmente los Pedidos en excel */

        public async Task<ActionResult> ExportarUnSoloPedidoEnExcel(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound($"El pedido con ID {id} no fue encontrado, por eso no se puede exportar en Excel.");
                }

                Pedido? pedido = await _context.DataPedido.FindAsync(id);

                if (pedido == null)
                {
                    return NotFound($"El pedido con ID {id} no fue encontrado, por eso no se puede exportar en Excel.");
                }

                ApplicationUser? cliente = await _context.Users.FirstOrDefaultAsync(u => u.UserName == pedido.UserID);

                if (cliente == null)
                {
                    return NotFound($"El cliente con ID {pedido.UserID} no fue encontrado en la tabla de Clientes.");
                }

                var detalles = (from detalle in _context.DataDetallePedido
                                join producto in _context.Producto on detalle.Producto.id equals producto.id
                                where detalle.pedido.ID == pedido.ID
                                select new
                                {
                                    Cantidad = detalle.Cantidad,
                                    PrecioUnitario = detalle.Precio,
                                    NombreProducto = producto.Nombre,
                                    DescripcionProducto = producto.Descripcion,
                                    Importe = detalle.Cantidad * detalle.Precio
                                }).ToList();

                using var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("Pedido");

                // Estilos personalizados
                var titleStyle = package.Workbook.Styles.CreateNamedStyle("TitleStyle");
                titleStyle.Style.Font.Size = 28; // Aumentado para que se vea proporcional al logo
                titleStyle.Style.Font.Bold = true;
                titleStyle.Style.Font.Color.SetColor(System.Drawing.Color.DarkBlue); // Cambiar el color de la fuente a azul oscuro
                titleStyle.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid; // Establecer un fondo sólido

                // prueba para ver el fondo del titulo y logo del archivo

                // 1.- titleStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray); // Color de fondo claro
                titleStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSkyBlue);  // Color de fondo Azul Suave
                // titleStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.MintCream);  // Color de fondo Verde Menta
                // titleStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Lavender);  // Color de fondo Lavanda
                // titleStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.MistyRose);  // Color de fondo Melocotón
                // titleStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gainsboro);  // Color de fondo Gris Neutro



                titleStyle.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Centrar horizontalmente
                titleStyle.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // Centrar verticalmente

                // <summary>

                var titleStyle2 = package.Workbook.Styles.CreateNamedStyle("TitleStyle2");
                titleStyle2.Style.Font.Size = 24; // Aumentado para que se vea proporcional al logo
                titleStyle2.Style.Font.Bold = true;

                // otro var de estilos de pruebas

                // otro var
                var headerStyle = package.Workbook.Styles.CreateNamedStyle("HeaderStyle");
                headerStyle.Style.Font.Bold = true;
                headerStyle.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                headerStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSkyBlue);
                headerStyle.Style.Font.Color.SetColor(System.Drawing.Color.DarkBlue);
                headerStyle.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Centrar horizontalmente
                headerStyle.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // Centrar verticalmente

                // para ponerle bordes a los encabezados de productos descripcion, etc
                headerStyle.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                headerStyle.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                headerStyle.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                headerStyle.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                headerStyle.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Estilo para los bordes de las celdas
                var borderStyle = package.Workbook.Styles.CreateNamedStyle("BorderStyle");
                borderStyle.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                borderStyle.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                borderStyle.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                borderStyle.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                borderStyle.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Información de la Empresa
                worksheet.Cells[1, 1].Value = "AthletiX";
                worksheet.Cells[1, 1].StyleName = "TitleStyle";
                worksheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // Alinear verticalmente en el centro
                worksheet.Cells["A1:E1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                worksheet.Row(1).Height = 80; // Ajusta el tamaño de la fila para el logo y el título

                // Descargar la imagen del logo
                using var client = new HttpClient();
                var logoBytes = await client.GetByteArrayAsync("https://firebasestorage.googleapis.com/v0/b/proyectos-cb445.appspot.com/o/img_logo_athletix.png?alt=media&token=a32e429b-4ece-45d2-bf00-85a8f9081a9c&_gl=1*14iryjj*_ga*MTcyOTkyMjIwMS4xNjk2NDU2NzU2*_ga_CW55HF8NVT*MTY5ODAxNDc6Mi4yLjEuMTY5ODAxNDg0Ny40OC4wLjA.");

                // Agregar la imagen al archivo Excel
                var image = worksheet.Drawings.AddPicture("Logo", new MemoryStream(logoBytes));
                image.SetPosition(0, 15, 3, 0); // Coloca el logo en la primera fila, columna E
                image.SetSize(100, 100);

                // Continuar con el resto de la información
                worksheet.Cells[2, 1].Value = "La Molina, Av. la Fontana 1250, Lima 15024";
                worksheet.Cells[3, 1].Value = "Teléfono: +51 927572267";
                worksheet.Cells[4, 1].Value = "Email: jesus_soria@usmp.pe";

                // Información del Cliente
                worksheet.Cells[6, 1].Value = "Información del Cliente:";
                worksheet.Cells[6, 1].StyleName = "titleStyle2";
                worksheet.Cells[7, 1].Value = $"Nombre: {cliente.Nombres} {cliente.Apellidos}";
                worksheet.Cells[8, 1].Value = $"Email: {cliente.Email}";

                // Detalles del Pedido
                worksheet.Cells[10, 1].Value = $"Factura N°: {id}";
                worksheet.Cells[11, 1].Value = $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
                worksheet.Cells[12, 1].Value = $"Estado del Pedido: {pedido.Status}";

                // Encabezados de la tabla de productos
                string[] encabezados = { "Producto", "Descripción", "Cantidad", "Precio Unitario (S/)", "Importe (S/)" };
                for (int i = 0; i < encabezados.Length; i++)
                {
                    worksheet.Cells[14, i + 1].Value = encabezados[i];
                    worksheet.Cells[14, i + 1].StyleName = "HeaderStyle";
                }

                worksheet.Row(14).Height = 20; // Ajusta el tamaño de la fila para el logo y el título

                // Combinar celdas para títulos
                worksheet.Cells["A1:E1"].Merge = true;
                worksheet.Cells["A6:E6"].Merge = true;


                // Llenar la tabla con los detalles
                int filaInicio = 15;
                foreach (var detalle in detalles)
                {
                    worksheet.Cells[filaInicio, 1].Value = detalle.NombreProducto;
                    worksheet.Cells[filaInicio, 2].Value = detalle.DescripcionProducto;
                    worksheet.Cells[filaInicio, 3].Value = detalle.Cantidad;
                    worksheet.Cells[filaInicio, 4].Value = detalle.PrecioUnitario;
                    worksheet.Cells[filaInicio, 5].Value = detalle.Importe;

                    // Colores alternos en filas
                    if (filaInicio % 2 == 0)
                    {
                        worksheet.Cells[filaInicio, 1, filaInicio, 5].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[filaInicio, 1, filaInicio, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(211, 211, 211)); // LightGray en ARGB
                    }

                    worksheet.Cells[filaInicio, 1, filaInicio, 5].StyleName = "BorderStyle"; // Aplicar bordes a las celdas de datos

                    filaInicio++;
                }

                // Totales
                worksheet.Cells[filaInicio + 1, 4].Value = "Subtotal:";
                worksheet.Cells[filaInicio + 1, 5].Value = detalles.Sum(d => d.Importe);
                worksheet.Cells[filaInicio + 2, 4].Value = "Total:";
                worksheet.Cells[filaInicio + 2, 5].Value = detalles.Sum(d => d.Importe); // Ajusta esto si agregas impuestos y descuentos

                // Aplicar el estilo headerStyle a las celdas "Subtotal" y "Total"
                worksheet.Cells[filaInicio + 1, 4].StyleName = "HeaderStyle";
                worksheet.Cells[filaInicio + 2, 4].StyleName = "HeaderStyle";

                // Aplicar bordes a las celdas "Subtotal", "Total" y sus montos
                worksheet.Cells[filaInicio + 1, 4, filaInicio + 2, 5].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[filaInicio + 1, 4, filaInicio + 2, 5].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[filaInicio + 1, 4, filaInicio + 2, 5].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[filaInicio + 1, 4, filaInicio + 2, 5].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                // Asegurarse de que los montos estén en negrita
                worksheet.Cells[filaInicio + 1, 5, filaInicio + 2, 5].Style.Font.Bold = true;

                // Formato de números
                worksheet.Cells[15, 3, filaInicio, 3].Style.Numberformat.Format = "#,##0";
                worksheet.Cells[15, 4, filaInicio + 2, 5].Style.Numberformat.Format = "#,##0.00";

                // Ajustar el ancho de las columnas automáticamente
                worksheet.Cells.AutoFitColumns();

                var stream = new MemoryStream();
                package.SaveAs(stream);

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Pedido_{id}.xlsx");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al exportar el pedido {id} a Excel");
                return StatusCode(500, $"Ocurrió un error al exportar el pedido {id} a Excel. Por favor, inténtelo de nuevo más tarde.");
            }
        }


        /* Hasta aqui son los metodos para exportar */

        /* metodo para buscar PEDIDO */

        public async Task<IActionResult> BuscarPedido(int? searchPedidoID, string? orderStatus)
        {
            // Declara la variable pedidosPagedList una sola vez aquí
            IPagedList<Pedido> pedidosPagedList;

            // Obtener el UserID del cliente logueado
            var userId = _userManager.GetUserName(User);

            if (userId == null)
            {
                // No se ha logueado
                TempData["MessageLOGUEARSE"] = "Por favor debe loguearse antes de buscar pedidos.";
                return View("~/Views/Home/Index.cshtml");
            }

            try
            {
                var pedidos = from o in _context.DataPedido where o.UserID == userId select o;

                if (searchPedidoID.HasValue && !String.IsNullOrEmpty(orderStatus))
                {
                    TempData["MessageDeRespuesta"] = "No se encontraron pedidos que coincidan con la búsqueda.";
                    pedidos = pedidos.Where(s => s.ID == searchPedidoID.Value && s.Status.Contains(orderStatus));
                }
                else if (searchPedidoID.HasValue)
                {
                    TempData["MessageDeRespuesta"] = "No se encontraron pedidos que coincidan con la búsqueda.";
                    pedidos = pedidos.Where(s => s.ID == searchPedidoID.Value);
                }
                else if (!String.IsNullOrEmpty(orderStatus))
                {
                    TempData["MessageDeRespuesta"] = "No se encontraron pedidos con el ESTADO ENTREGADO que coincidan con la búsqueda.";
                    pedidos = pedidos.Where(s => s.Status.Contains(orderStatus));
                }

                var pedidosList = await pedidos.ToListAsync();

                if (!pedidosList.Any())
                {
                    TempData["MessageDeRespuesta"] = "No se encontraron pedidos que coincidan con la búsqueda.";
                    pedidosPagedList = new PagedList<Pedido>(new List<Pedido>(), 1, 1);
                }
                else
                {
                    TempData["MessageDeRespuesta"] = "Si se encontraron pedidos que coincidan \ncon la búsqueda y son los siguientes.";

                    pedidosPagedList = pedidosList.ToPagedList(1, pedidosList.Count);
                }
            }
            catch (Exception ex)
            {
                TempData["MessageDeRespuesta"] = "Ocurrió un error al buscar pedidos. Por favor, inténtalo de nuevo más tarde.";
                pedidosPagedList = new PagedList<Pedido>(new List<Pedido>(), 1, 1);
            }

            // Retorna la vista con pedidosPagedList, que siempre tendrá un valor asignado.
            return View("MisPedidos", pedidosPagedList);
        }

        public async Task<IActionResult> VerPedido(int? id)
        {
            try
            {
                var pedido = await _context.DataPedido.FirstOrDefaultAsync(p => p.ID == id);

                if (pedido == null)
                {
                    return View("Error", new { message = "Pedido no encontrado." });
                }

                var detalles = (from detalle in _context.DataDetallePedido
                                join producto in _context.Producto on detalle.Producto.id equals producto.id
                                where detalle.pedido.ID == pedido.ID
                                select new DetallePedidoViewModel
                                {
                                    Cantidad = detalle.Cantidad,
                                    PrecioUnitario = detalle.Precio,
                                    NombreProducto = producto.Nombre,
                                    DescripcionProducto = producto.Descripcion,
                                    ImagenProducto = producto.Imagen,
                                    // SE PUEDE AGREGAR MAS CAMPOS DE LA TABLA PRODUCTO SI ASI LO QUIERES, ESTO PARA MI ES NECESARIO
                                }).ToList();

                var viewModel = new PedidoViewModel
                {
                    ID = pedido.ID,
                    Status = pedido.Status,
                    Items = detalles,
                    Total = pedido.Total
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Un error inesperado ocurrió mientras se obtenían los detalles del pedido.");
                return View("Error");
            }
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}