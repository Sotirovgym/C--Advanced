namespace _10._PredicateParty_
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var peoples = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var inputCommand = string.Empty;

            while ((inputCommand = Console.ReadLine()) != "Party!")
            {
                var CommandParams = inputCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (CommandParams[0])
                {
                    case "Remove":
                        RemovePeople(peoples, CommandParams);
                        break;
                    case "Double":
                        DoublePeoplesWith(peoples, CommandParams);
                        break;
                }
            }

            if (peoples.Count != 0)
            {
                Console.WriteLine(string.Join(", ", peoples) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void DoublePeoplesWith(System.Collections.Generic.List<string> peoples, string[] CommandParams)
        {
            var command = CommandParams[1];
            var parameter = CommandParams[2];
            string[] peoplesToAdd;
            switch (command)
            {
                case "StartsWith":
                    peoplesToAdd = peoples.Where(p => p.StartsWith(parameter)).ToArray();
                    for (int i = 0; i < peoplesToAdd.Length; i++)
                    {
                        var index = peoples.IndexOf(peoplesToAdd[i]);
                        peoples.Insert(index, peoplesToAdd[i]);
                    }
                    break;
                case "EndsWith":
                    peoplesToAdd = peoples.Where(p => p.EndsWith(parameter)).ToArray();
                    for (int i = 0; i < peoplesToAdd.Length; i++)
                    {
                        var index = peoples.IndexOf(peoplesToAdd[i]);
                        peoples.Insert(index, peoplesToAdd[i]);
                    }
                    break;
                case "Length":
                    peoplesToAdd = peoples.Where(p => p.Length == int.Parse(parameter)).ToArray();
                    for (int i = 0; i < peoplesToAdd.Length; i++)
                    {
                        var index = peoples.IndexOf(peoplesToAdd[i]);
                        peoples.Insert(index, peoplesToAdd[i]);
                    }
                    break;
            }
        }

        private static void RemovePeople(System.Collections.Generic.List<string> peoples, string[] CommandParams)
        {
            var command = CommandParams[1];
            var parameter = CommandParams[2];
            if (command == "StartsWith")
            {
                var peopleToRemove = peoples.Where(p => p.StartsWith(parameter)).ToArray();
                for (int i = 0; i < peopleToRemove.Length; i++)
                {
                    peoples.Remove(peopleToRemove[i]);
                }
            }
            else if (command == "EndsWith")
            {
                var peopleToRemove = peoples.Where(p => p.EndsWith(parameter)).ToArray();
                for (int i = 0; i < peopleToRemove.Length; i++)
                {
                    peoples.Remove(peopleToRemove[i]);
                }
            }
            else if (command == "Length")
            {
                var peopleToRemove = peoples.Where(p => p.Length == int.Parse(parameter)).ToArray();
                for (int i = 0; i < peopleToRemove.Length; i++)
                {
                    peoples.Remove(peopleToRemove[i]);
                }
            }
        }
    }
}
