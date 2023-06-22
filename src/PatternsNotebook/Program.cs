// See https://aka.ms/new-console-template for more information

using PatternsNotebook.Behavioral.Strategy.OrderExample;
using PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Export;
using PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;

var order = new Order("Customer", 2, "Item name", true, "Optional description");
var exportService = new XmlExportService();

order.Export(exportService);

order.NotifyWhenReady();

Console.ReadLine();