using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
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
                    { 1, null, new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(7696), null, null, "Admin", null, 1 },
                    { 2, null, new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(7764), null, null, "Member", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "Yaradılış Tarihi", "DeletedDate", "Description", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Tools", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(7784), null, "Quis quam minima quia dolor aliquam quia nesciunt nemo okuma.\nDe numquam quia çarpan sokaklarda mıknatıslı laudantium.\nBeatae gülüyorum aut anlamsız.\nMutlu mutlu mi orta.\nSevindi bilgiyasayarı telefonu uzattı.\nSıfat tempora ve ötekinden ad çobanın bundan sokaklarda.\nKoştum çarpan inventore aspernatur ki dolore aliquid nisi camisi doğru.\nSed ut domates aut.\nCommodi fugit koşuyorlar aut nostrum commodi ullam velit sevindi mi.\nMakinesi enim sayfası layıkıyla molestiae layıkıyla eaque karşıdakine nostrum.", null, 1 },
                    { 2, "Health", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(8287), null, "Sinema için ducimus.\nEnim laudantium okuma sandalye ki batarya ratione quae dolores eos.\nEsse ipsam ut dolayı aliquid labore sed quaerat.\nMinima quae deleniti aperiam rem.\nGül odio perferendis nostrum sit.\nEa makinesi makinesi okuma bilgiyasayarı quia.\nMasaya rem adanaya dışarı ratione ipsam.\nAd değerli ama illo quasi sed.\nDüşünüyor illo ama vel teldeki gördüm gazete.\nOlduğu adipisci doğru koyun koyun biber tempora qui koştum voluptas.", null, 1 },
                    { 3, "Movies", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(8502), null, "Dolorem quis magni.\nDucimus aut okuma biber quia qui ea karşıdakine.\nDeğerli veniam commodi için için.\nQuia yapacakmış ışık veniam adipisci telefonu praesentium karşıdakine beğendim.\nBiber blanditiis layıkıyla dolore et cezbelendi.\nCorporis dergi dolor layıkıyla dicta yazın karşıdakine.\nBilgiyasayarı beatae autem bilgisayarı commodi biber lambadaki.\nEsse fugit consequatur totam vel perferendis illo veritatis dağılımı.\nDicta dolor aspernatur otobüs voluptatum ona quia.\nDağılımı un bilgisayarı dolor.", null, 1 },
                    { 4, "Shoes", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(8716), null, "Exercitationem aut dergi orta okuma.\nEkşili nihil mıknatıslı quasi ötekinden otobüs et consequatur filmini.\nBilgisayarı quia değerli molestiae nemo qui perferendis.\nSokaklarda çarpan sandalye ki suscipit sequi teldeki otobüs cesurca.\nEt deleniti lakin değerli ut aperiam oldular exercitationem sıradanlıktan.\nUllam açılmadan umut ama inventore velit fugit.\nYapacakmış quis sit dışarı öyle in ea ipsam ipsum vitae.\nEve ut veniam umut ratione incidunt sayfası accusantium gül.\nVeniam neque değerli sarmal için.\nGöze mi non blanditiis cesurca quaerat.", null, 1 },
                    { 5, "Music", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(8921), null, "Consectetur makinesi mıknatıslı.\nOrta velit dignissimos orta makinesi eius açılmadan aliquid.\nDignissimos suscipit ex.\nDüşünüyor değerli oldular quam.\nOna layıkıyla corporis qui quia koştum mutlu anlamsız.\nSit ki bilgisayarı.\nAmet modi suscipit açılmadan.\nMolestiae sit yazın sevindi anlamsız öyle minima hesap koşuyorlar.\nCommodi eve adipisci değerli numquam aspernatur qui consequatur.\nAd magni ki iure exercitationem ut gidecekmiş yaptı.", null, 1 },
                    { 6, "Games", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(9084), null, "Ut ipsam sıfat sed sequi gül koştum.\nVelit mutlu sinema nesciunt quia yapacakmış dağılımı koştum in.\nAma sunt ullam dolorem.\nAmet tempora consequatur aut commodi iusto bundan nostrum olduğu sıfat.\nAnlamsız explicabo sit numquam sayfası kalemi voluptatem.\nMıknatıslı çorba nisi aut sinema gazete.\nİpsa velit yaptı ipsum.\nAdipisci ve qui et explicabo consequatur.\nDeğirmeni enim dolores duyulmamış minima göze aut dolorem neque.\nİnventore yazın öyle nihil tv adipisci.", null, 1 },
                    { 7, "Movies", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(9292), null, "Qui dergi voluptatem qui teldeki dicta aut vel bilgiyasayarı çakıl.\nMakinesi inventore quia illo gülüyorum minima batarya beğendim eaque aliquid.\nGöze cezbelendi quasi commodi quis veniam türemiş.\nNostrum batarya quae balıkhaneye.\nDomates masanın batarya dolor sıradanlıktan.\nBeğendim uzattı beğendim numquam oldular camisi çobanın.\nMakinesi çakıl sıla ipsam qui layıkıyla koşuyorlar.\nSayfası mi ut masaya et sit suscipit doğru eius.\nİpsa masaya incidunt.\nEius şafak quia yazın orta telefonu totam.", null, 1 },
                    { 8, "Games", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(9456), null, "Makinesi sevindi sevindi.\nConsequatur suscipit dolorem rem eius lambadaki ekşili.\nLayıkıyla ekşili lakin blanditiis sed ki dolores doloremque çorba molestiae.\nBilgisayarı ut molestiae gazete sed gülüyorum.\nBeğendim ut açılmadan labore.\nDolorem ut incidunt odio eos göze karşıdakine.\nConsequuntur gül beatae enim ki patlıcan magni otobüs.\nDeleniti sunt patlıcan.\nAut sarmal de nisi velit.\nFugit kapının çorba voluptatem odit.", null, 1 },
                    { 9, "Computers", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(9605), null, "Qui ex mutlu ışık.\nÇakıl ve çıktılar eum ut okuma labore.\nAperiam ex quis ki voluptatem aspernatur un quasi bahar alias.\nConsequatur qui dolor quia ki sunt voluptatem ab batarya.\nQui ona makinesi ut açılmadan.\nAb ut koyun.\nOdit cesurca batarya quasi ipsum labore masaya.\nEt et domates sunt gidecekmiş tempora quae mutlu aliquam.\nMinima mıknatıslı et sinema consequatur gül uzattı masaya.\nOrta de bilgisayarı incidunt ullam consequatur adanaya değerli.", null, 1 },
                    { 10, "Health", new DateTime(2024, 5, 21, 14, 43, 20, 427, DateTimeKind.Local).AddTicks(9790), null, "İpsum odit masaya odio şafak sevindi.\nOkuma numquam quaerat ama consectetur.\nEnim yazın koyun salladı dolorem tempora alias.\nOrta iure makinesi labore çorba.\nÇünkü sıfat sit dolorem eve dışarı patlıcan lakin sunt dolor.\nAut laudantium in eum sokaklarda teldeki domates beğendim quia dicta.\nİnventore düşünüyor çarpan illo inventore amet aliquid aut aut.\nAdanaya nihil sinema.\nQuia ducimus un accusantium sayfası dolores ekşili yapacakmış.\nIşık sequi eius inventore eve.", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Yaradılış Tarihi", "DeletedDate", "ImagePath", "ModifiedDate", "ProductName", "Status", "UnitInStock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(21), null, "http://lorempixel.com/640/480/nightlife", null, "Gorgeous Metal Hat", 1, 100, 555.19m },
                    { 2, 2, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(243), null, "http://lorempixel.com/640/480/nightlife", null, "Incredible Fresh Sausages", 1, 100, 514.94m },
                    { 3, 3, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(300), null, "http://lorempixel.com/640/480/nightlife", null, "Refined Fresh Keyboard", 1, 100, 463.66m },
                    { 4, 4, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(370), null, "http://lorempixel.com/640/480/nightlife", null, "Rustic Granite Ball", 1, 100, 278.82m },
                    { 5, 5, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(408), null, "http://lorempixel.com/640/480/nightlife", null, "Generic Concrete Tuna", 1, 100, 192.07m },
                    { 6, 6, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(452), null, "http://lorempixel.com/640/480/nightlife", null, "Ergonomic Rubber Chips", 1, 100, 389.40m },
                    { 7, 7, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(490), null, "http://lorempixel.com/640/480/nightlife", null, "Practical Metal Hat", 1, 100, 27.98m },
                    { 8, 8, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(527), null, "http://lorempixel.com/640/480/nightlife", null, "Small Soft Towels", 1, 100, 762.77m },
                    { 9, 9, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(601), null, "http://lorempixel.com/640/480/nightlife", null, "Handmade Rubber Computer", 1, 100, 254.17m },
                    { 10, 10, new DateTime(2024, 5, 21, 14, 43, 20, 428, DateTimeKind.Local).AddTicks(637), null, "http://lorempixel.com/640/480/nightlife", null, "Ergonomic Steel Gloves", 1, 100, 702.62m }
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
