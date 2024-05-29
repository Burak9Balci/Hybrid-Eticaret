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
                    Agree = table.Column<bool>(type: "bit", nullable: false),
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
                    { 1, null, new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(4742), null, null, "Admin", null, 1 },
                    { 2, null, new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(4802), null, null, "Member", null, 1 },
                    { 3, null, new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(4814), null, null, "Developer", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "Yaradılış Tarihi", "DeletedDate", "Description", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Sports", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(4829), null, "Koştum sıradanlıktan camisi teldeki sevindi.\nGidecekmiş sit sıradanlıktan suscipit gördüm aspernatur.\nCezbelendi koyun sit dolorem gülüyorum explicabo bilgisayarı qui numquam modi.\nQuis accusantium telefonu eum consequatur.\nÇünkü şafak voluptatem quis aut sarmal salladı.\nEt lambadaki nostrum et bahar quaerat.\nLaboriosam laudantium dağılımı voluptatem qui ut ut.\nİusto in quis nisi blanditiis un quasi ışık neque.\nŞafak düşünüyor ipsum consequuntur molestiae aut iure ipsum yaptı aut.\nQuia gülüyorum labore nisi otobüs totam camisi batarya tv.", null, 1 },
                    { 2, "Beauty", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(6265), null, "Teldeki quis gülüyorum autem un kutusu aut.\nQui gördüm orta ama consequuntur.\nMasaya sıfat adresini aperiam aut et praesentium nisi.\nNostrum neque enim doğru sıfat sed ama.\nİnventore kalemi yapacakmış nemo gazete.\nLabore magnam olduğu enim.\nİpsa lakin modi beğendim aut tv et.\nVoluptate ışık numquam quia enim ipsam ipsa ekşili.\nDignissimos nemo dignissimos enim nihil bilgiyasayarı dağılımı autem mıknatıslı.\nDeleniti in voluptatem ipsa et tv labore.", null, 1 },
                    { 3, "Games", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(6597), null, "Eaque rem labore beatae yaptı sit ut anlamsız.\nAccusantium gazete doloremque adanaya in voluptas sıradanlıktan.\nQuasi nesciunt fugit anlamsız et dignissimos mıknatıslı çorba sinema quam.\nDe patlıcan ducimus ea laudantium.\nMagni bilgiyasayarı voluptatem göze sequi sarmal voluptatum adipisci.\nKoyun ut ipsum filmini modi dergi.\nSunt suscipit mutlu praesentium alias amet dignissimos in ex.\nEt masaya quam.\nMasanın dicta un quia bilgisayarı de.\nVelit teldeki lambadaki iusto magnam domates bundan hesap.", null, 1 },
                    { 4, "Industrial", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(6844), null, "Layıkıyla magni de iure sandalye veniam voluptas sed lambadaki.\nSed yapacakmış veritatis batarya.\nAçılmadan bahar quaerat lambadaki velit sit bilgisayarı koyun ratione düşünüyor.\nUt mi qui odio.\nAutem sıfat architecto laudantium domates suscipit bundan quia karşıdakine.\nAlias in ve salladı mıknatıslı qui.\nLayıkıyla quia aspernatur orta koştum vitae mıknatıslı quis ötekinden sıla.\nSarmal dışarı ötekinden düşünüyor quasi cezbelendi mi.\nDışarı vel sokaklarda veniam dağılımı voluptatem consequatur doloremque.\nOdit çorba ötekinden et layıkıyla et çünkü sunt incidunt.", null, 1 },
                    { 5, "Health", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(7641), null, "Gördüm okuma ipsum fugit sit odio.\nVoluptate yaptı commodi.\nKoyun kutusu eos magni ötekinden.\nTv domates çobanın ea de gül.\nHesap dolores beğendim yapacakmış duyulmamış camisi.\nQuia beatae accusantium ekşili eos aut.\nQui incidunt ve reprehenderit dolore mi quia ad cesurca.\nOdit sıla dışarı voluptate tempora duyulmamış enim gazete neque layıkıyla.\nUzattı filmini voluptas suscipit un aspernatur de dolore göze eum.\nKi dışarı un ut balıkhaneye gülüyorum.", null, 1 },
                    { 6, "Home", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(7914), null, "Un sıla orta.\nİpsum filmini doloremque yaptı sit ea ve quis sıradanlıktan tv.\nPerferendis adanaya değirmeni.\nAb salladı quia inventore minima quia ratione aut cezbelendi qui.\nEum gitti dolorem.\nDolore qui aut aut yazın architecto.\nİn veniam kutusu yaptı yapacakmış nesciunt ekşili.\nBiber neque orta cezbelendi yapacakmış kalemi qui.\nMakinesi ona makinesi ama iusto beğendim gülüyorum koyun aut.\nVeritatis yazın qui enim esse.", null, 1 },
                    { 7, "Outdoors", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(8100), null, "Neque masaya ut minima amet voluptate illo quia çarpan karşıdakine.\nDoğru qui doloremque quis consequatur bilgiyasayarı sayfası değirmeni ipsam.\nDağılımı modi eum corporis yapacakmış tv ışık masanın.\nÇobanın et camisi sit.\nSıla gördüm quia.\nGülüyorum neque koştum.\nNostrum quis oldular gül.\nAliquid corporis consectetur aliquid salladı numquam voluptate.\nBlanditiis balıkhaneye sıla eius duyulmamış kutusu.\nAut tv domates quam magnam anlamsız çobanın totam değerli.", null, 1 },
                    { 8, "Home", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(8278), null, "Ötekinden salladı ona aperiam ea.\nSuscipit laboriosam illo adanaya enim ea.\nAdresini karşıdakine eum.\nAma ullam laboriosam ama sed.\nGidecekmiş anlamsız voluptate quia labore deleniti.\nAccusantium voluptatem mutlu veniam.\nReprehenderit accusantium doğru lambadaki quasi cesurca aspernatur.\nMasanın nisi ut değirmeni dolayı tempora veritatis öyle.\nSandalye iure dicta sayfası aliquam voluptate quae dicta sarmal.\nDoloremque voluptatem velit quia sed gazete aliquam gül illo quia.", null, 1 },
                    { 9, "Beauty", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(8453), null, "Quia telefonu gitti nihil öyle corporis labore.\nMıknatıslı quia dignissimos ona qui kutusu.\nAb magni velit ea mi quia.\nConsectetur ki eaque ve orta iusto in eos.\nKoştum deleniti ut praesentium ışık quia inventore layıkıyla bilgisayarı beatae.\nCorporis de et şafak quaerat qui.\nEnim consectetur bilgiyasayarı.\nOna adresini consequuntur suscipit quia voluptatem laboriosam.\nEt exercitationem çıktılar lakin suscipit enim doğru düşünüyor.\nOlduğu perferendis ut bundan eum kutusu eum praesentium ötekinden.", null, 1 },
                    { 10, "Kids", new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(8666), null, "Explicabo beğendim praesentium veniam karşıdakine incidunt.\nYaptı mi sıla.\nKarşıdakine reprehenderit eos laboriosam eos fugit teldeki koşuyorlar.\nCamisi ut molestiae voluptate eius ut.\nAçılmadan sandalye cesurca balıkhaneye ışık dolore et.\nGöze deleniti minima biber beatae ab voluptate koştum.\nSayfası ad ea doloremque doğru uzattı.\nSıradanlıktan voluptatum sıfat minima doğru.\nMagni dergi ipsam.\nLaboriosam göze tv beatae sit cezbelendi düşünüyor.", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Yaradılış Tarihi", "DeletedDate", "ImagePath", "ModifiedDate", "ProductName", "Status", "UnitInStock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(9499), null, "http://lorempixel.com/640/480/nightlife", null, "Licensed Concrete Keyboard", 1, 100, 552.85m },
                    { 2, 2, new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(9784), null, "http://lorempixel.com/640/480/nightlife", null, "Handcrafted Metal Keyboard", 1, 100, 232.59m },
                    { 3, 3, new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(9891), null, "http://lorempixel.com/640/480/nightlife", null, "Awesome Granite Hat", 1, 100, 992.80m },
                    { 4, 4, new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(9936), null, "http://lorempixel.com/640/480/nightlife", null, "Tasty Plastic Bacon", 1, 100, 260.34m },
                    { 5, 5, new DateTime(2024, 5, 29, 18, 45, 0, 617, DateTimeKind.Local).AddTicks(9976), null, "http://lorempixel.com/640/480/nightlife", null, "Generic Fresh Cheese", 1, 100, 176.54m },
                    { 6, 6, new DateTime(2024, 5, 29, 18, 45, 0, 618, DateTimeKind.Local).AddTicks(14), null, "http://lorempixel.com/640/480/nightlife", null, "Awesome Cotton Car", 1, 100, 183.84m },
                    { 7, 7, new DateTime(2024, 5, 29, 18, 45, 0, 618, DateTimeKind.Local).AddTicks(92), null, "http://lorempixel.com/640/480/nightlife", null, "Licensed Granite Mouse", 1, 100, 875.76m },
                    { 8, 8, new DateTime(2024, 5, 29, 18, 45, 0, 618, DateTimeKind.Local).AddTicks(130), null, "http://lorempixel.com/640/480/nightlife", null, "Gorgeous Wooden Sausages", 1, 100, 537.64m },
                    { 9, 9, new DateTime(2024, 5, 29, 18, 45, 0, 618, DateTimeKind.Local).AddTicks(167), null, "http://lorempixel.com/640/480/nightlife", null, "Incredible Steel Bacon", 1, 100, 911.31m },
                    { 10, 10, new DateTime(2024, 5, 29, 18, 45, 0, 618, DateTimeKind.Local).AddTicks(206), null, "http://lorempixel.com/640/480/nightlife", null, "Handcrafted Steel Tuna", 1, 100, 505.18m }
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
