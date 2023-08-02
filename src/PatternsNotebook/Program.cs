// See https://aka.ms/new-console-template for more information

using PatternsNotebook.Behavioral.ChainOfResponsibility.DocumentValidationExample;
using PatternsNotebook.Behavioral.Command.CartExample.Commands;
using PatternsNotebook.Behavioral.Command.CartExample.Repositories;
using PatternsNotebook.Behavioral.Command.CartExample.Repositories.Models;
using PatternsNotebook.Behavioral.Mediator.ChatRoomExample;
using PatternsNotebook.Behavioral.Observer.OrderStateChangeExample;
using PatternsNotebook.Behavioral.Specification.MovieExample;
using PatternsNotebook.Behavioral.State.BankAccountExample;
using PatternsNotebook.Behavioral.State.BookingExample;
using PatternsNotebook.Behavioral.Strategy.OrderExample;
using PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Export;
using PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;
using static System.Threading.Tasks.Task;

// STRATEGY USAGE
// var order = new Order("Customer", 2, "Item name", true, "Optional description");
// var exportService = new XmlExportService();
//
// order.Export(exportService);
//
// order.NotifyWhenReady();

// COMMAND USAGE
// ProductRepository productRepository = new ProductRepository();
// ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
// CommandManager manager = new CommandManager();
//
// shoppingCartRepository.Print();
// var addItem1 = new AddToCartCommand(shoppingCartRepository, productRepository, new Product("001", 0));
// var addItem2 = new AddToCartCommand(shoppingCartRepository, productRepository, new Product("002", 0));
// var addItem3 = new AddToCartCommand(shoppingCartRepository, productRepository, new Product("003", 0));
// var increaseItem1 = new ChangeQuantityCommand(ChangeQuantityCommand.Operation.Increase, shoppingCartRepository,
//     productRepository, new Product("001", 0));
// var increaseItem2 = new ChangeQuantityCommand(ChangeQuantityCommand.Operation.Increase, shoppingCartRepository,
//     productRepository, new Product("002", 0));
// var decreaseItem11 = new ChangeQuantityCommand(ChangeQuantityCommand.Operation.Decrease, shoppingCartRepository,
//     productRepository, new Product("001", 0));
// var decreaseItem12 = new ChangeQuantityCommand(ChangeQuantityCommand.Operation.Decrease, shoppingCartRepository,
//     productRepository, new Product("001", 0));
//
// manager.Invoke(addItem1);
// manager.Invoke(addItem2);
// manager.Invoke(addItem3);
// manager.Invoke(increaseItem1);
// manager.Invoke(increaseItem2);
// manager.Invoke(decreaseItem11);
// manager.Invoke(decreaseItem12);
//
// shoppingCartRepository.Print();
//
// manager.Undo();
//
// shoppingCartRepository.Print();

// SPECIFICATION USAGE
// var ticketsService = new TicketsService();
// var movieSearchService = new MovieSearchService();
//
// ticketsService.BuyTicketForAdult("002");
// ticketsService.BuyTicketForChild("002");
//
// var forChildrenOnlyFilter = new MovieFilter
// {
//     IsNotForChildren = true,
//     IsOnCd = true,
//     OrTitleContains = "extra"
// };
//
// var movies = movieSearchService.GetMovies(forChildrenOnlyFilter);
//
// foreach (var movie in movies)
// {
//     Console.WriteLine(movie.Title);
// }

// STATE USAGE
// var account = new BankAccount(200);
// account.Withdraw(100);
// account.Deposit(100);
// account.Withdraw(500);
// account.Withdraw(100);
// account.Deposit(1000);
// account.Withdraw(100);
// account.Deposit(1000);
// account.Deposit(100);
// account.Withdraw(100);

// MEDIATOR USAGE
// var teamChat = new TeamChatRoom();
// var peter = new Developer("Peter");
// var michael = new Developer("Michael");
// var mark = new Tester("Mark");
// var ann = new Tester("Ann");
// teamChat.RegisterMembers(peter, michael, mark, ann);
//
// michael.Send("Hi, I'm planning the deployment on friday afternoon");
// ann.Send("That's a great idea!");
//
// mark.SendTo<Developer>("I'm only writing to developers");

// OBSERVER USAGE
// var order = new StateNotifyingOrder();
// var mailService = new MailNotificationService();
// var deliveryService = new DeliveryService();
//
// order.AddObserver(mailService);
// order.AddObserver(deliveryService);
//
// order.SettlePayment();
// order.StartProcessing();
// order.Send();

// CHAIN OF RESPONSIBILITY USAGE
var validDocument = new Document("Valid document title", DateTimeOffset.UtcNow, true, true);
var invalidDocument = new Document("Valid title No 2", DateTimeOffset.UtcNow, false, true);

var validationChain = new DocumentTitleHandler();
validationChain
    .SetSuccessor(new DocumentLastModifiedHandler())
    .SetSuccessor(new DocumentApprovedByLitigationHandler())
    .SetSuccessor(new DocumentApprovedByManagementHandler());

try
{
    validationChain.Handle(validDocument);
    Console.WriteLine($"Document \"{validDocument.Title}\" validated.");
    validationChain.Handle(invalidDocument);
    Console.WriteLine($"Document \"{invalidDocument.Title}\" validated.");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();