// See https://aka.ms/new-console-template for more information

using PatternsNotebook.Behavioral.Command.CartExample.Commands;
using PatternsNotebook.Behavioral.Command.CartExample.Repositories;
using PatternsNotebook.Behavioral.Command.CartExample.Repositories.Models;
using PatternsNotebook.Behavioral.Strategy.OrderExample;
using PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Export;
using PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;

// STRATEGY USAGE
// var order = new Order("Customer", 2, "Item name", true, "Optional description");
// var exportService = new XmlExportService();
//
// order.Export(exportService);
//
// order.NotifyWhenReady();

// COMMAND USAGE
ProductRepository productRepository = new ProductRepository();
ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
CommandManager manager = new CommandManager();

shoppingCartRepository.Print();
var addItem1 = new AddToCartCommand(shoppingCartRepository, productRepository, new Product("001", 0));
var addItem2 = new AddToCartCommand(shoppingCartRepository, productRepository, new Product("002", 0));
var addItem3 = new AddToCartCommand(shoppingCartRepository, productRepository, new Product("003", 0));
var increaseItem1 = new ChangeQuantityCommand(ChangeQuantityCommand.Operation.Increase, shoppingCartRepository,
    productRepository, new Product("001", 0));
var increaseItem2 = new ChangeQuantityCommand(ChangeQuantityCommand.Operation.Increase, shoppingCartRepository,
    productRepository, new Product("002", 0));
var decreaseItem11 = new ChangeQuantityCommand(ChangeQuantityCommand.Operation.Decrease, shoppingCartRepository,
    productRepository, new Product("001", 0));
var decreaseItem12 = new ChangeQuantityCommand(ChangeQuantityCommand.Operation.Decrease, shoppingCartRepository,
    productRepository, new Product("001", 0));

manager.Invoke(addItem1);
manager.Invoke(addItem2);
manager.Invoke(addItem3);
manager.Invoke(increaseItem1);
manager.Invoke(increaseItem2);
manager.Invoke(decreaseItem11);
manager.Invoke(decreaseItem12);

shoppingCartRepository.Print();

manager.Undo();

shoppingCartRepository.Print();


Console.ReadLine();