using GuessTheNumber.Database;

namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dependency initialization
            INumberGenerator numberGenerator = new NumberGenerator();
            IUserInteractionService userInteractionService = new ConsoleUserInteractionService();
            IHintProvider hintProvider = new HintProvider();

            //game customization
            GameConfigurationManager gameConfigurationManager = new GameConfigurationManager(userInteractionService);
            GameConfiguration configuration = gameConfigurationManager.ConfigureGame();

            //Controlling the game logic
            Game game = new Game(userInteractionService, hintProvider, numberGenerator);
                        
            var gameResult = game.Run(configuration);

            //output statistics result
            if (configuration.TrackStatistics)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    bool isCreated = db.Database.EnsureCreated();

                    if (isCreated) Console.WriteLine("The database has been created");
                    else Console.WriteLine("Database already exists");

                    db.GameResults.Add(gameResult);
                    db.SaveChanges();
                    Console.WriteLine("The result of the game is saved in the database");
                }
            }
            
        }
    }
}