using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using WCFUI.ServiceReference1;

namespace WCFUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var sectionGroup = ServiceModelSectionGroup.GetSectionGroup(config);
            var endpoints = sectionGroup?.Client.Endpoints;
            var names = endpoints?.OfType<ChannelEndpointElement>().Select(endPoint => endPoint.Name).ToList();
            var services = names.Select(name => new UserServiceContractClient(name)).ToList();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("SERVICES:");
                for (var i = 0; i < services.Count; i++)
                {
                    Console.WriteLine(i + 1 + " - " + services[i].Endpoint.Address);
                }

                Console.WriteLine("\nChoose service:");
                int number;
                var parsed = int.TryParse(Console.ReadLine(), out number);

                if (parsed)
                {
                    ShowMenuFor(services[number - 1]);
                }
                else
                {
                    break;
                }
            }
        }

        private static void ShowMenuFor(UserServiceContractClient service)
        {
            var testUser = new BllUser { FirstNamek__BackingField = "Ben", LastNamek__BackingField = "Bernanke" };

            var isContinue = true;
            while (isContinue)
            {
                Console.Clear();
                Console.WriteLine("Press:\n 1 - to add\n 2 - to delete\n 3 - to search\n 4 - to exit");
                int number;
                var parsed = int.TryParse(Console.ReadLine(), out number);
                if (!parsed)
                {
                    Console.WriteLine("Wrong input! Press enter:");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    switch (number)
                    {
                        case 1:
                            service.Add(testUser);
                            Console.WriteLine("Added!\nPress enter:");
                            Console.ReadLine();
                            break;
                        case 2:
                            service.Delete(testUser);
                            Console.WriteLine("Deleted!\nPress enter:");
                            Console.ReadLine();
                            break;
                        case 3:
                            {
                                var users = service.SearchForUsers(new object[]
                                {
                                    new FirstNameCriterion { firstName = "Ben" },
                                    new LastNameCriterion { lastName = "Bernanke" },
                                    new IdCriterion { minId = 0, maxId = 1000 }
                                });
                                Console.WriteLine("Serch result: ");
                                foreach (var user in users)
                                {
                                    Console.Write(user + " ");
                                }

                                Console.WriteLine("Press enter:");
                                Console.ReadLine();
                            }

                            break;
                        case 4:
                            isContinue = false;
                            break;
                        default:
                            Console.WriteLine("Wrong command! Press enter:");
                            Console.ReadLine();
                            continue;
                    }
                }
                catch (FaultException ex)
                {
                    Console.WriteLine($"Wrong operation: {ex.Message}");
                    Console.WriteLine("\nPress enter to continue:");
                    Console.ReadLine();
                }
            }
        }
    }
}
