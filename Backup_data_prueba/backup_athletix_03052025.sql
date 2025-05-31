INSERT INTO public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") VALUES('1', 'Admin', NULL, NULL);
INSERT INTO public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") VALUES('2', 'Cliente', NULL, NULL);

INSERT INTO public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") VALUES('Google', '103780076797234881073', 'Google', 'd38a230b-49d0-412c-9449-d32e021ffe1f');

INSERT INTO public."AspNetUserRoles" ("UserId", "RoleId") VALUES('60079d14-e3cd-48a7-8e41-cac372e6f90f', '1');



INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('60079d14-e3cd-48a7-8e41-cac372e6f90f', 'jesus_soria@usmp.pe', 'JESUS_SORIA@USMP.PE', 'jesus_soria@usmp.pe', 'JESUS_SORIA@USMP.PE', true, 'AQAAAAIAAYagAAAAEDrdKCJNUVqv/uWkHkNwrox9ACh3ylCF6o8GcwjTCG+OMQ0rAuldcOnWdNmqPnh9pg==', 'RR6NARUDCBHCY45H4PSAM2CXDI5H7QZU', '3ae45bf2-323b-4cce-9810-9e8b7ec82b5e', NULL, false, false, NULL, true, 0, 'Admin 1', '73514145', 'Admin 1', 'Admin');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('7225750f-c62b-4ea9-9a02-ed115deb1bdb', 'julio_vera@usmp.pe', 'JULIO_VERA@USMP.PE', 'julio_vera@usmp.pe', 'JULIO_VERA@USMP.PE', true, 'AQAAAAIAAYagAAAAEDhjTnXAbx9MNU8pQ5ETYx0CWMxGZ8gMwPR9BuQTNaTySFENrvhX7s+U67l6ScH5FQ==', 'IAJPIQY7EKFEWNXGR234HRGP63VCVDX2', '00d0b595-21a0-43c5-9c19-addab1874bca', NULL, false, false, NULL, true, 0, 'Vera', '70928251', 'Julio Cesar', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('9e2e03b8-d94a-4c68-b7a5-faff2f0e71d8', 'miusuario@mailinator.com', 'MIUSUARIO@MAILINATOR.COM', 'miusuario@mailinator.com', 'MIUSUARIO@MAILINATOR.COM', true, 'AQAAAAIAAYagAAAAEBTKv4v3t8BwZr/G6ViKVIIZLXj1HaLXubZqlnUTQaLOcn+55Q86VVQcBXuwBpjbBA==', 'TC3DDUWH546BWZAFEPAMATHRHVNEQ23C', '6bf317fa-3532-4a0d-998e-214864999878', NULL, false, false, NULL, true, 0, 'Garcia Perez', '73514142', 'Juan', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('5eda674e-e2bf-48c4-ae1c-f0513c796827', 'aaa@gmail.com', 'AAA@GMAIL.COM', 'aaa@gmail.com', 'AAA@GMAIL.COM', true, 'AQAAAAIAAYagAAAAEJgnMrYwANAvo91fCSKrAv4ttlvFXDe2GoGCwywdrKraNpQ3FvNw4aLDzuIU1TsAHA==', 'P3MYPSAQNLC7EALUYXYDSMT4ZGBYQGGF', 'c443c07d-1fa7-4123-8a06-9ef83861566a', NULL, false, false, NULL, true, 0, 'Bodoqu', '77777778', 'Juan Carlo', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('8f11f769-940b-4772-8ab7-0846603afc4f', 'juanb@gmail.com', 'JUANB@GMAIL.COM', 'juanb@gmail.com', 'JUANB@GMAIL.COM', true, 'AQAAAAIAAYagAAAAEDRTkFRCJpGJqT9dY/n7wpIac84JSI7hidO2/1gnbzeb5AyRRqohQWaRRjO8FvMNCw==', 'RHUXE2KUCPYAVVBZJCNOFRXJHMQHTPQL', '3d54cb04-e58f-448b-9467-c5f13e7c1fce', NULL, false, false, NULL, true, 0, 'Bodoque', '70928255', 'Juan', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('761d1a7f-cf32-4aef-9edc-93767fe04a50', 'josemaria@yopmail.com', 'JOSEMARIA@YOPMAIL.COM', 'josemaria@yopmail.com', 'JOSEMARIA@YOPMAIL.COM', true, 'AQAAAAIAAYagAAAAEDhRAau5F952TBrdrnXX3+dEpVjIrj1j7Y07NpkzNZfcA0OsMCB1bAtkwdHinJjaBw==', 'WQL4YTE6XVAMJQGHLOV6PZVBBWC3DCK2', '93cbae9c-98f3-4570-87a2-58f71c2f4c43', NULL, false, false, NULL, true, 0, 'Maria', '74068280', 'Jose', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('b8102c0e-4608-419c-96d2-bba299fa7d0d', 'o@gmail.com', 'O@GMAIL.COM', 'o@gmail.com', 'O@GMAIL.COM', true, 'AQAAAAIAAYagAAAAEJvUMwyVoNrJxXjQRQd+97SOvsPx62GixCGvDCTCfaaj/Cf9s/SdUaTIYP6EhxGb7Q==', 'KXSV3R5ICZIGTDIM3K7UNXOHM6JH7C2Y', '68798449-ec84-4956-8cd2-e5485e0817b3', NULL, false, false, NULL, true, 0, 'safasf', '45345333', 'assaf', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('d38a230b-49d0-412c-9449-d32e021ffe1f', 'yisusoria@gmail.com', 'YISUSORIA@GMAIL.COM', 'yisusoria@gmail.com', 'YISUSORIA@GMAIL.COM', true, NULL, '65RVHXVANOJD4MGECBHDPEAVRWL7X4CZ', 'f35ca9ac-f1ca-4d31-937f-c8037cfecf2a', NULL, false, false, NULL, true, 0, 'Soria Llantoy', '73514144', 'Jesus', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('97d8bc19-bf00-4ad6-9851-48afb12f919b', 'albertosoriasoria74@gmail.com', 'ALBERTOSORIASORIA74@GMAIL.COM', 'albertosoriasoria74@gmail.com', 'ALBERTOSORIASORIA74@GMAIL.COM', true, 'AQAAAAIAAYagAAAAEBR358E71hWvowYcUl9j8Ob30IysjtP4vV8/LnE2xybMWvQp8+vM3A4zUqgJScmJSg==', '7VWAUFLLJYFGRQ3WSVTNGKO433NHS5CT', '21ec9b82-ebc9-44d3-aaa9-53667ed38035', NULL, false, false, NULL, true, 0, 'Soria Llantoy', '73514143', 'Alberto', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('19ff034a-ec60-49e6-8877-3e13d41ceb1b', 'franco_sanchez2@usmp.pe', 'FRANCO_SANCHEZ2@USMP.PE', 'franco_sanchez2@usmp.pe', 'FRANCO_SANCHEZ2@USMP.PE', true, 'AQAAAAIAAYagAAAAED3khzzsYhWv/EPO/Rfmr3jw+Gkkx6sGVsuiMkSQbhMaiP1cK9W4R2RkIiGX52cLTg==', 'IQSRNPNXQGBR4NZYPZPXHN22NOGKRDLZ', '015a4b73-d603-4d49-b0d9-db56143004dc', NULL, false, false, NULL, true, 0, 'Sanchez Villalobos', '73045456', 'Franco Jesus', 'Cliente');
INSERT INTO public."AspNetUsers"
("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Apellidos", "Dni", "Nombres", "Rol")
VALUES('e0553980-b63a-4220-8a9d-b03de8d1e808', 'nuevo@gmail.com', 'NUEVO@GMAIL.COM', 'nuevo@gmail.com', 'NUEVO@GMAIL.COM', true, 'AQAAAAIAAYagAAAAENTaXDMwWPnGqm1o3JacJjtEcaWg8OPRfmv7gqFea4ve3PSYZY3SzkQVPyN8V1PDBA==', 'VPUEWRUNKE4CNOMR47E5OEYY5VYNUTLR', 'da4019c0-0413-4d32-bf46-1e61de66bd4f', NULL, false, false, NULL, true, 0, 'salazar', '12345645', 'jose jose', 'Cliente');


INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(107, 'ISO Whey Protein', 'Proteína marca ISO WHEY de alta calidad', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fiso_whey_prot.jpg?alt=media&token=1190a7b0-94b2-4a76-abf3-56e9b0a5edff', 209.0, 79, '2024-03-14 00:00:00.000', '2024-03-14 00:00:00.000');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(106, 'Creatina monohidratada', 'Cantidad 300 gr', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fcreatina_monoh.jpg?alt=media&token=afbe63db-46fd-42eb-bb17-48c2e049e48d', 95.0, 79, '2024-03-14 00:00:00.000', '2025-04-17 11:58:01.429');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(109, ' Guantes Deportivos', ' Guantes Deportivos Con Muñequera Para Gimnasio Y Ciclismo', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fguantes_deportivos.jpg?alt=media&token=f61367d4-f200-4478-8c3b-83b552fed469', 59.0, 75, '2024-03-14 00:00:00.000', '2025-04-17 12:01:17.943');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(102, 'PUSH UP LEGGINGS | SCRUNCH | WASHED BLACK', '¡Entrena con comodidad y confianza en el gimnasio!', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fleggings.jpg?alt=media&token=050750d8-8eac-40e3-8c94-14865cb422c1', 129.0, 160, '2024-03-14 00:00:00.000', '2024-03-14 00:00:00.000');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(105, 'IMAPC WHEY PROTEIN', 'Este suero de alta calidad incluye 19 g de proteína por ración', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fimapc_protein.jpg?alt=media&token=af915e7d-d27c-4d8e-bd3c-85c32b91c234', 250.0, 80, '2024-03-14 00:00:00.000', '2024-03-14 00:00:00.000');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(110, 'Polo Deportivo de Compresión para Hombres', 'Polo de compresión color negro talla XL', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fpolo_compresivo_hombre.jpg?alt=media&token=241c4f9b-e129-4cc9-b44f-137a4cd86763', 100.0, 80, '2024-03-14 00:00:00.000', '2024-03-14 00:00:00.000');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(101, 'WORKOUT TEE | POLO DEPORTIVO | NEGRO II', 'Inyéctale energía a tus entrenamientos.', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fpolo_deportivo.jpg?alt=media&token=4446723e-12ab-4702-bc27-b55d6ec0d898', 105.0, 146, '2024-03-14 00:00:00.000', '2024-03-14 00:00:00.000');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(103, 'Whey Protein 500g', 'Cantidad 300 gr', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fwhey_protein.jpg?alt=media&token=49a6f6b6-7868-4359-9614-dc02c076991b', 199.0, 79, '2024-03-14 00:00:00.000', '2024-03-14 00:00:00.000');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(104, 'Proteina DT', 'Proteina de alta calidad', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fproteina_dt.jpg?alt=media&token=1e2b09f1-e346-432f-b91a-9f6e6abde80d', 199.0, 76, '2024-03-14 00:00:00.000', '2024-03-14 00:00:00.000');
INSERT INTO public."Producto"
(id, "Nombre", "Descripcion", "Imagen", "Precio", "Stock", "fechaCreacion", "fechaActualizacion")
VALUES(108, 'Suplemento de proteina 1', '1Kg de proteina', 'https://firebasestorage.googleapis.com/v0/b/proyecto20112023-6e784.appspot.com/o/Prueba%2Fsuplemento_prot.jpg?alt=media&token=f608d85f-2ccb-4506-9529-4aa371759172', 100.0, 78, '2024-03-14 00:00:00.000', '2024-03-14 00:00:00.000');



INSERT INTO public.t_contacto
(id, "Nombre", "Email", "Phone", "Asunto", "Mensaje")
VALUES(101, 'Franco Sanchez', 'franco_sanchez2@usmp.pe', '943572212', 'PRUEBA 1 DEL 15/03/2025', 'PRUEBA 1 DEL 15/03/2025');
INSERT INTO public.t_contacto
(id, "Nombre", "Email", "Phone", "Asunto", "Mensaje")
VALUES(102, 'Franco Sanchez', 'franco_sanchez2@usmp.pe', '943572212', 'Prueba 2', 'Prueba 2');
INSERT INTO public.t_contacto
(id, "Nombre", "Email", "Phone", "Asunto", "Mensaje")
VALUES(103, 'Franco Sanchez', 'franco_sanchez2@usmp.pe', '943572212', 'INFORMACIÓN DE LOS PRODUCTOS', 'Solicito mayor información de los productos en el catalogo por favor.');
INSERT INTO public.t_contacto
(id, "Nombre", "Email", "Phone", "Asunto", "Mensaje")
VALUES(104, 'Franco Sanchez', 'franco_sanchez2@usmp.pe', '943572212', 'INFORMACIÓN DE LOS PRODUCTOS', 'Solicito mayor información de los productos');
INSERT INTO public.t_contacto
(id, "Nombre", "Email", "Phone", "Asunto", "Mensaje")
VALUES(105, 'Franco Sanchez', 'franco_sanchez2@usmp.pe', '943572212', 'INFORMACIÓN DE LOS PRODUCTOS', 'Solicito mayor información de los productos');
INSERT INTO public.t_contacto
(id, "Nombre", "Email", "Phone", "Asunto", "Mensaje")
VALUES(111, 'Franco Sanchez', 'Prueba 11', 'Prueba 11', 'Prueba 11', 'Prueba 11');

INSERT INTO public.t_pago
(id, "PaymentDate", "NombreTarjeta", "NumeroTarjeta", "MontoTotal", "UserID")
VALUES(101, '2025-03-14 23:43:22.821', 'FRANCO SANCHEZ', '1234 5678 9124 2134', 236.0, 'franco_sanchez2@usmp.pe');
INSERT INTO public.t_pago
(id, "PaymentDate", "NombreTarjeta", "NumeroTarjeta", "MontoTotal", "UserID")
VALUES(102, '2025-03-15 11:50:16.260', 'JESUS SORIA', '1234 1234 1234 1234', 420.0, 'yisusoria@gmail.com');
INSERT INTO public.t_pago
(id, "PaymentDate", "NombreTarjeta", "NumeroTarjeta", "MontoTotal", "UserID")
VALUES(103, '2025-03-22 13:49:06.778', '2144124', '2144 124', 199.0, 'tulio@gmail.com');
INSERT INTO public.t_pago
(id, "PaymentDate", "NombreTarjeta", "NumeroTarjeta", "MontoTotal", "UserID")
VALUES(110, '2025-04-17 11:00:04.691', 'JESUS SORIA', '1234 1234 1234 1234', 996.0, 'albertosoriasoria74@gmail.com');
INSERT INTO public.t_pago
(id, "PaymentDate", "NombreTarjeta", "NumeroTarjeta", "MontoTotal", "UserID")
VALUES(111, '2025-04-17 11:02:04.235', 'JESUS SORIA', '1234 1234 1234 1234', 155.0, 'albertosoriasoria74@gmail.com');
INSERT INTO public.t_pago
(id, "PaymentDate", "NombreTarjeta", "NumeroTarjeta", "MontoTotal", "UserID")
VALUES(112, '2025-04-17 11:05:00.092', 'JESUS SORIA', '1231 1231 1231 1231', 209.0, 'albertosoriasoria74@gmail.com');


INSERT INTO public.t_order
(id, "UserID", "Total", "pagoId", "Status")
VALUES(103, 'tulio@gmail.com', 199.0, 103, 'PENDIENTE');
INSERT INTO public.t_order
(id, "UserID", "Total", "pagoId", "Status")
VALUES(101, 'franco_sanchez2@usmp.pe', 236.0, 101, 'ENTREGADO');
INSERT INTO public.t_order
(id, "UserID", "Total", "pagoId", "Status")
VALUES(102, 'yisusoria@gmail.com', 420.0, 102, 'ENTREGADO');
INSERT INTO public.t_order
(id, "UserID", "Total", "pagoId", "Status")
VALUES(107, 'albertosoriasoria74@gmail.com', 996.0, 110, 'PENDIENTE');
INSERT INTO public.t_order
(id, "UserID", "Total", "pagoId", "Status")
VALUES(108, 'albertosoriasoria74@gmail.com', 155.0, 111, 'PENDIENTE');
INSERT INTO public.t_order
(id, "UserID", "Total", "pagoId", "Status")
VALUES(109, 'albertosoriasoria74@gmail.com', 209.0, 112, 'PENDIENTE');



INSERT INTO public.t_order_detail
(id, "Productoid", "Cantidad", "Precio", "pedidoID")
VALUES(101, 109, 4, 59.0, 101);
INSERT INTO public.t_order_detail
(id, "Productoid", "Cantidad", "Precio", "pedidoID")
VALUES(102, 101, 4, 105.0, 102);
INSERT INTO public.t_order_detail
(id, "Productoid", "Cantidad", "Precio", "pedidoID")
VALUES(103, 103, 1, 199.0, 103);
INSERT INTO public.t_order_detail
(id, "Productoid", "Cantidad", "Precio", "pedidoID")
VALUES(104, 104, 4, 199.0, 107);
INSERT INTO public.t_order_detail
(id, "Productoid", "Cantidad", "Precio", "pedidoID")
VALUES(105, 108, 2, 100.0, 107);
INSERT INTO public.t_order_detail
(id, "Productoid", "Cantidad", "Precio", "pedidoID")
VALUES(106, 109, 1, 59.0, 108);
INSERT INTO public.t_order_detail
(id, "Productoid", "Cantidad", "Precio", "pedidoID")
VALUES(107, 106, 1, 96.0, 108);
INSERT INTO public.t_order_detail
(id, "Productoid", "Cantidad", "Precio", "pedidoID")
VALUES(108, 107, 1, 209.0, 109);



INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(101, 'franco_sanchez2@usmp.pe', 109, 4, 59.0, 'PROCESADO');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(102, 'yisusoria@gmail.com', 101, 4, 105.0, 'PROCESADO');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(104, 'tulio@gmail.com', 103, 1, 199.0, 'PROCESADO');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(105, 'yasseravalosmontero14@gmail.com', 106, 1, 96.0, 'PENDIENTE');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(106, 'yasseravalosmontero14@gmail.com', 104, 1, 199.0, 'PENDIENTE');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(107, 'josemaria@yopmail.com', 104, 1, 199.0, 'PENDIENTE');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(108, 'albertosoriasoria74@gmail.com', 104, 4, 199.0, 'PROCESADO');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(109, 'albertosoriasoria74@gmail.com', 108, 2, 100.0, 'PROCESADO');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(110, 'albertosoriasoria74@gmail.com', 109, 1, 59.0, 'PROCESADO');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(111, 'albertosoriasoria74@gmail.com', 106, 1, 96.0, 'PROCESADO');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(112, 'albertosoriasoria74@gmail.com', 107, 1, 209.0, 'PROCESADO');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(113, 'julio_vera@usmp.pe', 107, 1, 209.0, 'PENDIENTE');
INSERT INTO public.t_proforma
(id, "UserID", "Productoid", "Cantidad", "Precio", "Status")
VALUES(114, 'julio_vera@usmp.pe', 106, 3, 95.0, 'PENDIENTE');





INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('00000000000000_CreateIdentitySchema', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20230923024550_InitialMigration', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20230923033932_AgregueProductoMigration', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20230928101009_UpdateIdentityUser1', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20230928103328_UpdateApellidosField2', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20230928104155_UpdateUserFields3', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20230928201753_ProformaMigration', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20230928204039_ContactoMigration', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20230929183647_AddRolToApplicationUser', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20231008194339_AddPagoPedidoMigration', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20231027154554_Service', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20250309003221_PruebasSMigration', '7.0.11');
INSERT INTO public."__EFMigrationsHistory"
("MigrationId", "ProductVersion")
VALUES('20250404070823_SegundaDBMigration', '7.0.11');


----- Eliminar en este orden la data

--Primero eliminar en este orden
DELETE FROM public."t_proforma"
DELETE FROM public."t_contacto"
DELETE FROM public."t_order_detail"
DELETE FROM public."t_order"
DELETE FROM public."t_pago"
DELETE FROM public."Producto"