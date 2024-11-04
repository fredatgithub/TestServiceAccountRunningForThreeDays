using System;
using System.IO;
using System.Threading;
using log4net.Config;
using log4net;

namespace TestServiceAccountRunningForThreeDays
{
  internal static class Program
  {
    static void Main()
    {
      ILog logger = LogManager.GetLogger(typeof(Program));
      const string Log4NetConfigFilePath = "log4net.config.xml";
      XmlConfigurator.ConfigureAndWatch(new FileInfo(Log4NetConfigFilePath));
      Action<string> Display = Console.WriteLine;
      Display("Voici un test d'application console pour tester si une tâche lancée par un compte de service peut durer 3 jours");
      var startDate = DateTime.Now;
      var endDate = startDate.AddDays(3);
      logger.Info("Début du traitement");
      while (DateTime.Now < endDate)
      {
        string message = $"log = {DateTime.Now}";
        logger.Info(message);
        Thread.Sleep(60000);
      }

      logger.Info("fin du traitement");
    }
  }
}
