using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi_DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierId = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    quantityPerUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitsInStock = table.Column<int>(type: "int", nullable: false),
                    unitsOnOrder = table.Column<int>(type: "int", nullable: false),
                    reorderLevel = table.Column<int>(type: "int", nullable: false),
                    discontinued = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "Suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Soft drinks coffees teas beers and ales", "Beverages" },
                    { 2, "Sweet and savory sauces relishes spreads and seasonings", "Condiments" },
                    { 3, "Desserts candies and sweet breads", "Confections" },
                    { 4, "Cheeses", "Dairy Products" },
                    { 5, "Breads crackers pasta and cereal", "Grains/Cereals" },
                    { 6, "Prepared meats", "Meat/Poultry" },
                    { 7, "Dried fruit and bean curd", "Produce" },
                    { 8, "Seaweed and fish", "Seafood" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "id", "companyName", "contactName", "contactTitle", "strAddress" },
                values: new object[,]
                {
                    { 1, "Exotic Liquids", "Charlotte Cooper", "Purchasing Manager", "49 Gilbert St. London NULL EC1 4SD UK (171) 555-2222" },
                    { 2, "New Orleans Cajun Delights", "Shelley Burke", "Order Administrator", "P.O. Box 78934 New Orleans LA 70117 USA (100) 555-4822" },
                    { 3, "Grandma Kelly's Homestead", "Regina Murphy", "Sales Representative", "707 Oxford Rd. Ann Arbor MI 48104 USA (313) 555-5735" },
                    { 4, "Tokyo Traders", "Yoshi Nagase", "Marketing Manager", "9-8 Sekimai Musashino-shi Tokyo NULL 100 Japan (03) 3555-5011" },
                    { 5, "Cooperativa de Quesos 'Las Cabras'", "Antonio del Valle Saavedra", "Export Administrator", "Calle del Rosal 4 Oviedo Asturias 33007 Spain (98) 598 76 54" },
                    { 6, "Mayumi's", "Mayumi Ohno", "Marketing Representative", "92 Setsuko Chuo-ku Osaka NULL 545 Japan (06) 431-7877" },
                    { 7, "Pavlova Ltd.", "Ian Devling", "Marketing Manager", "74 Rose St. Moonie Ponds Melbourne Victoria 3058 Australia (03) 444-2343" },
                    { 8, "Specialty Biscuits Ltd.", "Peter Wilson", "Sales Representative", "29 King's Way Manchester NULL M14 GSD UK (161) 555-4448" },
                    { 9, "PB Knäckebröd AB", "Lars Peterson", "Sales Agent", "Kaloadagatan 13 Göteborg NULL S-345 67 Sweden 031-987 65 43" },
                    { 10, "Refrescos Americanas LTDA", "Carlos Diaz", "Marketing Manager", "Av. das Americanas 12.890 Sao Paulo NULL 5442 Brazil (11) 555 4640" },
                    { 11, "Heli Süßwaren GmbH & Co. KG", "Petra Winkler", "Sales Manager", "Tiergartenstraße 5 Berlin NULL 10785 Germany (010) 9984510" },
                    { 12, "Plutzer Lebensmittelgroßmärkte AG", "Martin Bein", "International Marketing Mgr.", "Bogenallee 51 Frankfurt NULL 60439 Germany (069) 992755" },
                    { 13, "Nord-Ost-Fisch Handelsgesellschaft mbH", "Sven Petersen", "Coordinator Foreign Markets", "Frahmredder 112a Cuxhaven NULL 27478 Germany (04721) 8713" },
                    { 14, "Formaggi Fortini s.r.l.", "Elio Rossi", "Sales Representative", "Viale Dante 75 Ravenna NULL 48100 Italy (0544) 60323" },
                    { 15, "Norske Meierier", "Beate Vileid", "Marketing Manager", "Hatlevegen 5 Sandvika NULL 1320 Norway (0)2-953010" },
                    { 16, "Bigfoot Breweries", "Cheryl Saylor", "Regional Account Rep.", "3400 - 8th Avenue Suite 210 Bend OR 97101 USA (503) 555-9931" },
                    { 17, "Svensk Sjöföda AB", "Michael Björn", "Sales Representative", "Brovallavägen 231 Stockholm NULL S-123 45 Sweden 08-123 45 67" },
                    { 18, "Aux joyeux ecclésiastiques", "Guylène Nodier", "Sales Manager", "203 Rue des Francs-Bourgeois Paris NULL 75004 France (1) 03.83.00.68" },
                    { 19, "New England Seafood Cannery", "Robb Merchant", "Wholesale Account Agent", "Order Processing Dept. 2100 Paul Revere Blvd. Boston MA 2134 USA (617) 555-3267" },
                    { 20, "Leka Trading", "Chandra Leka", "Owner", "471 Serangoon Loop Suite #402 Singapore NULL 512 Singapore 555-8787" },
                    { 21, "Lyngbysild", "Niels Petersen", "Sales Manager", "Lyngbysild Fiskebakken 10 Lyngby NULL 2800 Denmark 43844108" },
                    { 22, "Zaanse Snoepfabriek", "Dirk Luchte", "Accounting Manager", "Verkoop Rijnweg 22 Zaandam NULL 9999 ZZ Netherlands (12345) 1212" },
                    { 23, "Karkki Oy", "Anne Heikkonen", "Product Manager", "Valtakatu 12 Lappeenranta NULL 53120 Finland (953) 10956" },
                    { 24, "G'day Mate", "Wendy Mackenzie", "Sales Representative", "170 Prince Edward Parade Hunter's Hill Sydney NSW 2042 Australia (02) 555-5914" },
                    { 25, "Ma Maison", "Jean-Guy Lauzon", "Marketing Manager", "2960 Rue St. Laurent Montréal Québec H1J 1C3 Canada (514) 555-9022" },
                    { 26, "Pasta Buttini s.r.l.", "Giovanni Giudici", "Order Administrator", "Via dei Gelsomini 153 Salerno NULL 84100 Italy (089) 6547665" },
                    { 27, "Escargots Nouveaux", "Marie Delamare", "Sales Manager", "22 rue H. Voiron Montceau NULL 71300 France 85.57.00.07" },
                    { 28, "Gai pâturage", "Eliane Noz", "Sales Representative", "Bat. B 3 rue des Alpes Annecy NULL 74000 France 38.76.98.06" },
                    { 29, "Forêts d'érables", "Chantal Goulet", "Accounting Manager", "148 rue Chasseur Ste-Hyacinthe Québec J2S 7S8 Canada (514) 555-2955" },
                    { 30, "aaaaaaa", "a", null, "     a" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "categoryId", "discontinued", "name", "quantityPerUnit", "reorderLevel", "supplierId", "unitPrice", "unitsInStock", "unitsOnOrder" },
                values: new object[,]
                {
                    { 1, 1, false, "Chai", "10 boxes x 20 bags", 10, 1, 18m, 39, 0 },
                    { 2, 1, false, "Chang", "24 - 12 oz bottles", 25, 1, 19m, 17, 40 },
                    { 3, 2, false, "Aniseed Syrup", "12 - 550 ml bottles", 25, 1, 10m, 13, 70 },
                    { 4, 3, true, "Chef Anton's Cajun Seasoning", "48 - 6 oz jars", 0, 2, 22m, 53, 0 },
                    { 5, 2, true, "Chef Anton's Gumbo Mix", "36 boxes", 0, 2, 21.35m, 0, 0 },
                    { 6, 2, false, "Grandma's Boysenberry Spread", "12 - 8 oz jars", 25, 3, 25m, 120, 0 },
                    { 7, 7, false, "Uncle Bob's Organic Dried Pears", "12 - 1 lb pkgs.", 10, 3, 30m, 15, 0 },
                    { 8, 2, false, "Northwoods Cranberry Sauce", "12 - 12 oz jars", 0, 3, 40m, 6, 0 },
                    { 9, 6, true, "Mishi Kobe Niku", "18 - 500 g pkgs.", 0, 4, 97m, 29, 0 },
                    { 10, 8, false, "Ikura", "12 - 200 ml jars", 0, 4, 31m, 31, 0 },
                    { 11, 2, false, "Queso Cabrales 2", "1 kg pkg.", 30, 5, 21m, 22, 30 },
                    { 12, 4, false, "Queso Manchego La Pastora", "10 - 500 g pkgs.", 0, 5, 38m, 86, 0 },
                    { 13, 8, false, "Konbu", "2 kg box", 5, 6, 6m, 24, 0 },
                    { 14, 7, false, "Tofu", "40 - 100 g pkgs.", 0, 6, 23.25m, 35, 0 },
                    { 15, 2, false, "Genen Shouyu", "24 - 250 ml bottles", 5, 6, 15.5m, 39, 0 },
                    { 16, 3, false, "Pavlova", "32 - 500 g boxes", 10, 7, 17.45m, 29, 0 },
                    { 17, 6, true, "Alice Mutton", "20 - 1 kg tins", 0, 7, 39m, 0, 0 },
                    { 18, 8, false, "Carnarvon Tigers", "16 kg pkg.", 0, 7, 62.5m, 42, 0 },
                    { 19, 3, false, "Teatime Chocolate Biscuits", "10 boxes x 12 pieces", 5, 8, 9.2m, 25, 0 },
                    { 20, 3, false, "Sir Rodney's Marmalade", "30 gift boxes", 0, 8, 81m, 40, 0 },
                    { 21, 3, false, "Sir Rodney's Scones", "24 pkgs. x 4 pieces", 5, 8, 10m, 3, 40 },
                    { 22, 5, false, "Gustaf's Knäckebröd", "24 - 500 g pkgs.", 25, 9, 21m, 104, 0 },
                    { 23, 5, false, "Tunnbröd", "12 - 250 g pkgs.", 25, 9, 9m, 61, 0 },
                    { 24, 1, true, "Guaraná Fantástica", "12 - 355 ml cans", 0, 10, 4.5m, 20, 0 },
                    { 25, 3, false, "NuNuCa Nuß-Nougat-Creme", "20 - 450 g glasses", 30, 11, 14m, 76, 0 },
                    { 26, 3, false, "Gumbär Gummibärchen", "100 - 250 g bags", 0, 11, 31.23m, 15, 0 },
                    { 27, 3, false, "Schoggi Schokolade", "100 - 100 g pieces", 30, 11, 43.9m, 49, 0 },
                    { 28, 7, true, "Rössle Sauerkraut", "25 - 825 g cans", 0, 12, 45.6m, 26, 0 },
                    { 29, 6, true, "Thüringer Rostbratwurst", "50 bags x 30 sausgs.", 0, 12, 123.79m, 0, 0 },
                    { 30, 8, false, "Nord-Ost Matjeshering", "10 - 200 g glasses", 15, 13, 25.89m, 10, 0 },
                    { 31, 4, false, "Gorgonzola Telino", "12 - 100 g pkgs", 20, 14, 12.5m, 0, 70 },
                    { 32, 4, false, "Mascarpone Fabioli", "24 - 200 g pkgs.", 25, 14, 32m, 9, 40 },
                    { 33, 4, false, "Geitost", "500 g", 20, 15, 2.5m, 112, 0 },
                    { 34, 1, false, "Sasquatch Ale", "24 - 12 oz bottles", 15, 16, 14m, 111, 0 },
                    { 35, 1, false, "Steeleye Stout", "24 - 12 oz bottles", 15, 16, 18m, 20, 0 },
                    { 36, 8, false, "Inlagd Sill", "24 - 250 g  jars", 20, 17, 19m, 112, 0 },
                    { 37, 8, false, "Gravad lax", "12 - 500 g pkgs.", 25, 17, 26m, 11, 50 },
                    { 38, 1, false, "Côte de Blaye", "12 - 75 cl bottles", 15, 18, 263.5m, 17, 0 },
                    { 39, 1, false, "Chartreuse verte", "750 cc per bottle", 5, 18, 18m, 69, 0 },
                    { 40, 8, false, "Boston Crab Meat", "24 - 4 oz tins", 30, 19, 18.4m, 123, 0 },
                    { 41, 8, false, "Jack's New England Clam Chowder", "12 - 12 oz cans", 10, 19, 9.65m, 85, 0 },
                    { 42, 5, true, "Singaporean Hokkien Fried Mee", "32 - 1 kg pkgs.", 0, 20, 14m, 26, 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "categoryId", "discontinued", "name", "quantityPerUnit", "reorderLevel", "supplierId", "unitPrice", "unitsInStock", "unitsOnOrder" },
                values: new object[,]
                {
                    { 43, 1, false, "Ipoh Coffee", "16 - 500 g tins", 25, 20, 46m, 17, 10 },
                    { 44, 2, false, "Gula Malacca", "20 - 2 kg bags", 15, 20, 19.45m, 27, 0 },
                    { 45, 8, false, "Rogede sild", "1k pkg.", 15, 21, 9.5m, 5, 70 },
                    { 46, 8, false, "Spegesild", "4 - 450 g glasses", 0, 21, 12m, 95, 0 },
                    { 47, 3, false, "Zaanse koeken", "10 - 4 oz boxes", 0, 22, 9.5m, 36, 0 },
                    { 48, 3, false, "Chocolade", "10 pkgs.", 25, 22, 12.75m, 15, 70 },
                    { 49, 3, false, "Maxilaku", "24 - 50 g pkgs.", 15, 23, 20m, 10, 60 },
                    { 50, 3, false, "Valkoinen suklaa", "12 - 100 g bars", 30, 23, 16.25m, 65, 0 },
                    { 51, 7, false, "Manjimup Dried Apples", "50 - 300 g pkgs.", 10, 24, 53m, 20, 0 },
                    { 52, 5, false, "Filo Mix", "16 - 2 kg boxes", 25, 24, 7m, 38, 0 },
                    { 53, 6, true, "Perth Pasties", "48 pieces", 0, 24, 32.8m, 0, 0 },
                    { 54, 6, false, "Tourtière", "16 pies", 10, 25, 7.45m, 21, 0 },
                    { 55, 6, false, "Pâté chinois", "24 boxes x 2 pies", 20, 25, 24m, 115, 0 },
                    { 56, 5, false, "Gnocchi di nonna Alice", "24 - 250 g pkgs.", 30, 26, 38m, 21, 10 },
                    { 57, 5, false, "Ravioli Angelo", "24 - 250 g pkgs.", 20, 26, 19.5m, 36, 0 },
                    { 58, 8, false, "Escargots de Bourgogne", "24 pieces", 20, 27, 13.25m, 62, 0 },
                    { 59, 4, false, "Raclette Courdavault", "5 kg pkg.", 0, 28, 55m, 79, 0 },
                    { 60, 4, false, "Camembert Pierrot", "15 - 300 g rounds", 0, 28, 34m, 19, 0 },
                    { 61, 2, false, "Sirop d'érable", "24 - 500 ml bottles", 25, 29, 28.5m, 113, 0 },
                    { 62, 3, false, "Tarte au sucre", "48 pies", 0, 29, 49.3m, 17, 0 },
                    { 63, 2, false, "Vegie-spread", "15 - 625 g jars", 5, 7, 43.9m, 24, 0 },
                    { 64, 5, false, "Wimmers gute Semmelknödel", "20 bags x 4 pieces", 30, 12, 33.25m, 22, 80 },
                    { 65, 2, false, "Louisiana Fiery Hot Pepper Sauce", "32 - 8 oz bottles", 0, 2, 21.05m, 76, 0 },
                    { 66, 2, false, "Louisiana Hot Spiced Okra", "24 - 8 oz jars", 20, 2, 17m, 4, 100 },
                    { 67, 1, false, "Laughing Lumberjack Lager", "24 - 12 oz bottles", 10, 16, 14m, 52, 0 },
                    { 68, 3, false, "Scottish Longbreads", "10 boxes x 8 pieces", 15, 8, 12.5m, 6, 10 },
                    { 69, 4, false, "Gudbrandsdalsost", "10 kg pkg.", 15, 15, 36m, 26, 0 },
                    { 70, 1, false, "Outback Lager", "24 - 355 ml bottles", 30, 7, 15m, 15, 10 },
                    { 71, 4, false, "Flotemysost", "10 - 500 g pkgs.", 0, 15, 21.5m, 26, 0 },
                    { 72, 4, false, "Mozzarella di Giovanni", "24 - 200 g pkgs.", 0, 14, 34.8m, 14, 0 },
                    { 73, 8, false, "Röd Kaviar", "24 - 150 g jars", 5, 17, 15m, 101, 0 },
                    { 74, 7, false, "Longlife Tofu", "5 kg pkg.", 5, 4, 10m, 4, 20 },
                    { 75, 1, false, "Rhönbräu Klosterbier", "24 - 0.5 l bottles", 25, 12, 7.75m, 125, 0 },
                    { 76, 1, false, "Lakkalikööri", "500 ml", 20, 23, 18m, 57, 0 },
                    { 77, 2, false, "Original Frankfurter grüne Soße", "12 boxes", 15, 12, 13m, 32, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_supplierId",
                table: "Products",
                column: "supplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
