using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Index : Migration
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
                    { 1, null, new DateTime(2024, 5, 19, 20, 48, 36, 540, DateTimeKind.Local).AddTicks(9889), null, null, "Admin", null, 1 },
                    { 2, null, new DateTime(2024, 5, 19, 20, 48, 36, 540, DateTimeKind.Local).AddTicks(9963), null, null, "Member", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "Yaradılış Tarihi", "DeletedDate", "Description", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Books", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(31), null, "Dolor sayfası voluptatum eius salladı eius nisi.\nEkşili nostrum mi ipsum corporis.\nOrta ab quia aut ipsa explicabo.\nNihil ut voluptatem.\nÖyle tv aliquam masaya exercitationem.\nÇünkü beatae çıktılar minima.\nSit quaerat non.\nTeldeki domates umut mutlu iure minima.\nKarşıdakine inventore voluptatem quis.\nVe sandalye quia commodi.", null, 1 },
                    { 2, "Music", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(647), null, "Sayfası voluptatum nostrum ışık vitae kulu ducimus ipsam architecto anlamsız.\nSinema adanaya vitae consequatur iure vel quasi illo alias türemiş.\nQuia masaya voluptatum fugit adresini balıkhaneye perferendis ut doğru sıla.\nBilgisayarı tempora lambadaki ut sıla ki çünkü ki quia.\nAd reprehenderit consectetur bilgisayarı dignissimos deleniti.\nDolayı dağılımı kalemi makinesi ex sit şafak düşünüyor.\nAliquid qui batarya reprehenderit eius lambadaki.\nNeque ex domates blanditiis.\nUt masaya ad.\nQuis esse praesentium.", null, 1 },
                    { 3, "Health", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(906), null, "Sıradanlıktan quis iure voluptatem sevindi.\nVoluptatum adanaya ab değerli sed qui doloremque.\nCamisi suscipit biber çünkü filmini.\nAut sequi değerli nostrum.\nVeritatis nemo sarmal dolorem ratione bundan gül quae ullam gördüm.\nSalladı velit minima koyun veniam.\nDüşünüyor minima adipisci anlamsız illo.\nSuscipit qui veniam ullam camisi.\nEa inventore adresini mi sıfat.\nQui mıknatıslı in.", null, 1 },
                    { 4, "Toys", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(1101), null, "Dışarı için perferendis.\nGitti nostrum dicta laboriosam adipisci.\nTempora ona sıla sit çakıl mıknatıslı.\nQuam deleniti qui orta otobüs ut ona sıla voluptatem.\nBalıkhaneye voluptate amet et iure blanditiis dicta yazın.\nQui camisi alias perferendis magnam.\nYaptı gül sinema sandalye tempora uzattı çakıl için.\nYaptı un kalemi molestiae.\nBlanditiis camisi deleniti qui dışarı totam sandalye sed.\nKoşuyorlar ötekinden gazete adipisci ki quasi sıla.", null, 1 },
                    { 5, "Movies", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(1306), null, "Ut quasi quia sequi.\nMagni aut düşünüyor dağılımı dergi vel.\nVoluptate et dolayı otobüs kapının accusantium.\nİpsa gördüm dolor quasi aperiam totam.\nBilgisayarı laboriosam kulu eaque.\nAut reprehenderit kutusu filmini consectetur batarya architecto.\nQuia mutlu architecto.\nSed dignissimos layıkıyla dicta qui masaya numquam sokaklarda.\nŞafak cesurca sıfat vitae gidecekmiş.\nLaboriosam batarya neque molestiae sokaklarda gidecekmiş bahar exercitationem vitae değirmeni.", null, 1 },
                    { 6, "Automotive", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(1503), null, "Nostrum labore magni domates quae quis.\nUn iure ut quis.\nOna batarya ipsum lambadaki ve.\nBeğendim architecto minima ad ut eum illo.\nEnim dolore nemo.\nDolayı inventore ama otobüs nostrum esse veritatis düşünüyor gitti.\nSuscipit bilgisayarı et gazete duyulmamış consequatur bilgisayarı.\nPerferendis masaya quasi nostrum blanditiis göze gazete laboriosam exercitationem.\nDignissimos ipsam quis ona commodi voluptate fugit ve consequatur corporis.\nÇorba gül consectetur reprehenderit bilgiyasayarı eius sinema oldular dolor.", null, 1 },
                    { 7, "Movies", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(1700), null, "Enim dergi sokaklarda.\nAdresini dışarı sayfası ad enim layıkıyla vitae voluptas bilgisayarı perferendis.\nÇakıl mıknatıslı aut nostrum sıla nostrum çakıl dicta suscipit tempora.\nAdipisci incidunt sit kalemi iure ab patlıcan eius.\nGazete sunt çünkü umut odit voluptatem bahar non masanın.\nTelefonu uzattı ex praesentium.\nAdipisci sıfat reprehenderit ekşili için sequi minima teldeki laudantium.\nVelit koştum corporis sinema salladı.\nSed aliquid cezbelendi çarpan camisi masaya.\nKulu düşünüyor çıktılar çıktılar explicabo fugit çorba sed.", null, 1 },
                    { 8, "Grocery", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(1894), null, "Alias suscipit beatae.\nUmut consequatur tv rem quia ex anlamsız sunt ad.\nKoştum praesentium ut voluptatem dolor masaya açılmadan nemo voluptatem.\nPatlıcan olduğu un dolayı sit.\nEnim umut beğendim çarpan velit koştum.\nHesap deleniti domates ipsa kulu velit.\nEt reprehenderit teldeki yapacakmış oldular çünkü.\nConsequatur mıknatıslı kapının okuma quia camisi et alias adipisci.\nOlduğu quia teldeki.\nLabore de sokaklarda adanaya exercitationem.", null, 1 },
                    { 9, "Health", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(2092), null, "Sit sunt adipisci accusantium tv quia quia oldular ab.\nOldular ab dignissimos.\nQuia dolore layıkıyla.\nDignissimos nesciunt dolor nostrum.\nMıknatıslı autem ducimus et ullam bundan bundan aliquam amet.\nDergi salladı qui voluptatum ötekinden beatae.\nGördüm göze cesurca explicabo ötekinden qui sıla mi duyulmamış.\nEaque praesentium anlamsız uzattı yazın enim yapacakmış.\nBahar laboriosam iusto gitti kapının olduğu.\nMinima commodi adresini.", null, 1 },
                    { 10, "Books", new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(2358), null, "Dolor alias gülüyorum kapının eius adipisci koştum non.\nConsequatur ut kutusu vel ex vel ea un ipsum architecto.\nModi praesentium telefonu consequatur adanaya blanditiis modi dolore.\nGördüm commodi quis.\nSıradanlıktan ötekinden perferendis tv çünkü ut sokaklarda uzattı gülüyorum.\nVel quia aliquam consequuntur değerli.\nDışarı aliquid architecto otobüs.\nÇobanın beğendim çünkü hesap lambadaki umut sit teldeki iure iusto.\nUn quae kulu ki patlıcan beatae düşünüyor.\nVoluptatem ut otobüs gülüyorum ullam explicabo sıfat değerli.", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Yaradılış Tarihi", "DeletedDate", "ImagePath", "ModifiedDate", "ProductName", "Status", "UnitInStock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(2686), null, "http://lorempixel.com/640/480/nightlife", null, "Tasty Rubber Pizza", 1, 100, 356.89m },
                    { 2, 2, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(2952), null, "http://lorempixel.com/640/480/nightlife", null, "Intelligent Soft Bike", 1, 100, 494.77m },
                    { 3, 3, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(3045), null, "http://lorempixel.com/640/480/nightlife", null, "Incredible Plastic Pizza", 1, 100, 509.05m },
                    { 4, 4, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(3090), null, "http://lorempixel.com/640/480/nightlife", null, "Awesome Cotton Tuna", 1, 100, 686.28m },
                    { 5, 5, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(3132), null, "http://lorempixel.com/640/480/nightlife", null, "Sleek Soft Cheese", 1, 100, 233.81m },
                    { 6, 6, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(3172), null, "http://lorempixel.com/640/480/nightlife", null, "Rustic Frozen Bike", 1, 100, 328.28m },
                    { 7, 7, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(3230), null, "http://lorempixel.com/640/480/nightlife", null, "Intelligent Cotton Towels", 1, 100, 9.68m },
                    { 8, 8, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(3269), null, "http://lorempixel.com/640/480/nightlife", null, "Refined Fresh Keyboard", 1, 100, 680.33m },
                    { 9, 9, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(3310), null, "http://lorempixel.com/640/480/nightlife", null, "Rustic Frozen Table", 1, 100, 877.90m },
                    { 10, 10, new DateTime(2024, 5, 19, 20, 48, 36, 541, DateTimeKind.Local).AddTicks(3349), null, "http://lorempixel.com/640/480/nightlife", null, "Incredible Frozen Bike", 1, 100, 384.34m }
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
