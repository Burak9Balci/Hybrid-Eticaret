using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class gg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YaradılışTarihi = table.Column<DateTime>(name: "Yaradılış Tarihi", type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YaradılışTarihi = table.Column<DateTime>(name: "Yaradılış Tarihi", type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YaradılışTarihi = table.Column<DateTime>(name: "Yaradılış Tarihi", type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    YaradılışTarihi = table.Column<DateTime>(name: "Yaradılış Tarihi", type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    YaradılışTarihi = table.Column<DateTime>(name: "Yaradılış Tarihi", type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YaradılışTarihi = table.Column<DateTime>(name: "Yaradılış Tarihi", type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_ID",
                        column: x => x.ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitInStock = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    YaradılışTarihi = table.Column<DateTime>(name: "Yaradılış Tarihi", type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YaradılışTarihi = table.Column<DateTime>(name: "Yaradılış Tarihi", type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Yaradılış Tarihi", "DeletedDate", "ModifiedDate", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(8311), null, null, "Admin", null, 1 },
                    { 2, null, new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(8359), null, null, "Member", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "Yaradılış Tarihi", "DeletedDate", "Description", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Automotive", new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(8401), null, "Dağılımı öyle aut consequatur sit magnam gül ipsam gitti camisi.\nVoluptatem doğru voluptatem balıkhaneye enim laboriosam alias minima aut.\nMinima ışık salladı voluptatem consequuntur kulu çakıl.\nÇünkü doğru masanın filmini değirmeni laboriosam qui ea gülüyorum aperiam.\nUt qui vitae çorba consequuntur perferendis.\nBatarya ut odit ut qui.\nHesap aliquid hesap çakıl veniam veniam.\nDüşünüyor esse voluptatum rem oldular vitae öyle eve.\nQui teldeki ut enim magnam layıkıyla ducimus çarpan dignissimos.\nNisi gidecekmiş laboriosam.", null, 1 },
                    { 2, "Kids", new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(8960), null, "Salladı ona ut.\nÇakıl ki türemiş sokaklarda et filmini voluptatem.\nKoştum kalemi masanın.\nYazın mıknatıslı veritatis quia ut consequatur.\nAmet gül gördüm sit sevindi ötekinden eve.\nNisi ipsum mutlu değirmeni voluptatum.\nQuis çobanın veritatis.\nVoluptatem alias aut vitae perferendis ona exercitationem dolorem.\nTv türemiş sed aut mutlu ea.\nTv ışık kulu ea vitae sokaklarda eaque qui ex quam.", null, 1 },
                    { 3, "Baby", new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(9166), null, "İpsa duyulmamış çobanın et bilgiyasayarı laudantium gazete.\nSalladı eve mıknatıslı totam voluptatem ut bundan eum.\nNumquam praesentium sit velit koşuyorlar architecto voluptatem bilgisayarı ratione.\nEve adanaya çobanın quasi.\nÖtekinden eum ipsam aperiam balıkhaneye.\nLaudantium çakıl kalemi camisi.\nTv velit çobanın.\nTüremiş lambadaki gitti eve.\nİncidunt nesciunt quia consequatur dolor tv karşıdakine ipsa eum ratione.\nUmut dolore perferendis camisi et beğendim sokaklarda quis odit dolore.", null, 1 },
                    { 4, "Garden", new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(9362), null, "Mıknatıslı labore molestiae salladı cesurca.\nGazete odio veritatis çıktılar lambadaki teldeki nihil.\nSıla masaya beğendim.\nYaptı consequuntur batarya doloremque.\nAlias adipisci aut.\nConsequatur quis voluptatum gitti labore illo uzattı.\nMolestiae dicta quis iusto eos göze.\nSit corporis quia.\nBahar beatae dignissimos türemiş.\nOna aliquid çünkü vitae ötekinden kalemi nisi nisi.", null, 1 },
                    { 5, "Toys", new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(9548), null, "Sarmal bundan sed ad incidunt dolores esse dolore et laboriosam.\nAma bahar sıradanlıktan sevindi filmini mutlu.\nNostrum sokaklarda filmini bilgisayarı ut accusantium oldular laudantium.\nRem dicta masanın odit sarmal.\nTelefonu göze odit ab nihil ut.\nVeniam quasi umut amet ki layıkıyla aperiam dolor cezbelendi.\nİure filmini autem masaya göze bahar.\nOtobüs göze magnam.\nCesurca telefonu iure.\nArchitecto et ut dolore.", null, 1 },
                    { 6, "Kids", new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(9728), null, "Voluptate ona telefonu iure gidecekmiş consequuntur dignissimos labore.\nVoluptatem gülüyorum sinema.\nAdanaya göze aliquid ipsum gitti illo.\nEt magnam kutusu masanın uzattı otobüs voluptatem türemiş orta kalemi.\nBatarya veritatis un gülüyorum açılmadan de magnam consequatur değerli magnam.\nLakin architecto türemiş nihil ipsa corporis filmini.\nAliquid eius uzattı.\nİpsum ipsam kutusu kapının.\nAdanaya filmini de layıkıyla oldular veniam ut mi ki.\nNisi kalemi bahar quaerat consectetur çorba eius alias yaptı gülüyorum.", null, 1 },
                    { 7, "Toys", new DateTime(2024, 5, 27, 22, 57, 5, 816, DateTimeKind.Local).AddTicks(9902), null, "Cezbelendi telefonu sıradanlıktan magni.\nEa voluptatem non ipsa dağılımı filmini masanın otobüs bilgisayarı ducimus.\nConsequatur aut sed.\nDoğru koşuyorlar nihil değirmeni orta sit.\nQui gitti exercitationem yazın.\nKoştum yazın camisi odio batarya qui lakin in minima oldular.\nMagnam gül architecto çıktılar nostrum değerli modi bahar eos.\nBundan açılmadan ki ratione olduğu sit göze anlamsız labore masaya.\nKutusu okuma ipsa velit beatae aliquam lambadaki.\nSıfat sevindi voluptatem commodi gördüm.", null, 1 },
                    { 8, "Sports", new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(71), null, "Velit koştum batarya.\nDuyulmamış kutusu consequatur laudantium reprehenderit değerli neque teldeki sunt.\nNon layıkıyla yapacakmış neque ışık enim.\nTempora non ab adresini quia düşünüyor değirmeni patlıcan corporis.\nEt masanın öyle dolorem doğru ut aut.\nLambadaki adanaya aut beğendim ona voluptatem.\nÇıktılar çünkü ducimus corporis mutlu enim.\nAut velit sed inventore ama non karşıdakine.\nAdresini iure autem kutusu sinema koyun için laboriosam alias.\nNihil vel dolores sed nemo değirmeni.", null, 1 },
                    { 9, "Outdoors", new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(275), null, "Odit illo molestiae ad sarmal ipsum quam mıknatıslı.\nÇobanın aliquid aut layıkıyla bilgisayarı öyle un fugit.\nNesciunt in şafak quaerat nostrum.\nBatarya voluptas minima.\nVoluptatem sit blanditiis nemo amet.\nSarmal quia enim.\nDe tv ea göze nesciunt.\nÇünkü ad otobüs değirmeni.\nEius sokaklarda sandalye yaptı mıknatıslı.\nIşık değerli ut ipsam adresini ad.", null, 1 },
                    { 10, "Automotive", new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(423), null, "Ratione non mıknatıslı odit.\nMıknatıslı adanaya dışarı ekşili sandalye layıkıyla.\nGülüyorum tempora aut ışık çakıl consequatur.\nMagni makinesi aut değirmeni ipsa dergi un nisi doloremque.\nSandalye magnam gül architecto.\nEve makinesi incidunt doğru modi öyle.\nİçin cesurca ullam voluptatum masanın bilgisayarı quia numquam teldeki lakin.\nExercitationem gül iusto değirmeni sunt duyulmamış ex.\nAliquid sed çakıl.\nMakinesi odit masanın değirmeni aut odio çakıl ut.", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Yaradılış Tarihi", "DeletedDate", "ImagePath", "ModifiedDate", "ProductName", "Status", "UnitInStock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(635), null, "http://lorempixel.com/640/480/nightlife", null, "Small Frozen Chips", 1, 100, 35.20m },
                    { 2, 2, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(850), null, "http://lorempixel.com/640/480/nightlife", null, "Incredible Steel Bike", 1, 100, 324.38m },
                    { 3, 3, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(930), null, "http://lorempixel.com/640/480/nightlife", null, "Small Concrete Bacon", 1, 100, 324.36m },
                    { 4, 4, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(975), null, "http://lorempixel.com/640/480/nightlife", null, "Generic Soft Sausages", 1, 100, 616.86m },
                    { 5, 5, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(1016), null, "http://lorempixel.com/640/480/nightlife", null, "Rustic Metal Computer", 1, 100, 327.34m },
                    { 6, 6, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(1058), null, "http://lorempixel.com/640/480/nightlife", null, "Refined Rubber Salad", 1, 100, 72.84m },
                    { 7, 7, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(1099), null, "http://lorempixel.com/640/480/nightlife", null, "Generic Soft Gloves", 1, 100, 630.71m },
                    { 8, 8, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(1175), null, "http://lorempixel.com/640/480/nightlife", null, "Gorgeous Soft Keyboard", 1, 100, 721.47m },
                    { 9, 9, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(1213), null, "http://lorempixel.com/640/480/nightlife", null, "Small Concrete Cheese", 1, 100, 513.75m },
                    { 10, 10, new DateTime(2024, 5, 27, 22, 57, 5, 817, DateTimeKind.Local).AddTicks(1254), null, "http://lorempixel.com/640/480/nightlife", null, "Handmade Fresh Table", 1, 100, 471.05m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserID",
                table: "Orders",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
