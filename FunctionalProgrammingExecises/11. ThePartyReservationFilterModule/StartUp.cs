namespace _11._ThePartyReservationFilterModule
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            var peoples = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var inputCommand = string.Empty;
            var removeFilter = new List<string>();

            while ((inputCommand = Console.ReadLine()) != "Print")
            {
                var CommandParams = inputCommand.Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = $"{CommandParams[0]} {CommandParams[1]}";
                var filterType = string.Empty; ;
                var filterParamater = string.Empty;
                if (CommandParams.Length == 5)
                {
                    filterType = $"{CommandParams[2]} {CommandParams[3]}";
                    filterParamater = CommandParams[4];
                }
                else if (CommandParams.Length == 4)
                {
                    filterType = CommandParams[2];
                    filterParamater = CommandParams[3];
                }

                switch (command)
                {
                    case "Add filter":
                        RemoveElement(peoples, filterType, filterParamater, removeFilter);
                        break;
                    case "Remove filter":
                        AddElement(peoples, filterType, filterParamater, removeFilter);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", peoples));
        }

        private static void AddElement(List<string> peoples, string filterType, string filterParamater, List<string> removeFilter)
        {
            string[] elementsToAdd;
            switch (filterType)
            {
                case "Starts with":
                    elementsToAdd = removeFilter.Where(p => p.StartsWith(filterParamater)).ToArray();
                    for (int i = 0; i < elementsToAdd.Length; i++)
                    {
                        peoples.Insert(0, elementsToAdd[i]);
                    }
                    break;
                case "Ends with":
                    elementsToAdd = removeFilter.Where(p => p.EndsWith(filterParamater)).ToArray();
                    for (int i = 0; i < elementsToAdd.Length; i++)
                    {
                        peoples.Insert(0, elementsToAdd[i]);
                    }
                    break;
                case "Length":
                    elementsToAdd = removeFilter.Where(p => p.Length == int.Parse(filterParamater)).ToArray();
                    for (int i = 0; i < elementsToAdd.Length; i++)
                    {
                        peoples.Insert(0, elementsToAdd[i]);
                    }
                    break;
                case "Contains":
                    elementsToAdd = removeFilter.Where(p => p.Contains(filterParamater)).ToArray();
                    for (int i = 0; i < elementsToAdd.Length; i++)
                    {
                        peoples.Insert(0, elementsToAdd[i]);
                    }
                    break;
            }
        }

        private static void RemoveElement(List<string> peoples, string filterType, string filterParamater, List<string> removeFilter)
        {
            string[] elementsToRemove;
            switch (filterType)
            {
                case "Starts with":
                    elementsToRemove = peoples.Where(p => p.StartsWith(filterParamater)).ToArray();
                    for (int i = 0; i < elementsToRemove.Length; i++)
                    {
                        removeFilter.Add(elementsToRemove[i]);
                        peoples.Remove(elementsToRemove[i]);
                    }
                    break;
                case "Ends with":
                    elementsToRemove = peoples.Where(p => p.EndsWith(filterParamater)).ToArray();
                    for (int i = 0; i < elementsToRemove.Length; i++)
                    {
                        removeFilter.Add(elementsToRemove[i]);
                        peoples.Remove(elementsToRemove[i]);
                    }
                    break;
                case "Length":
                    elementsToRemove = peoples.Where(p => p.Length == int.Parse(filterParamater)).ToArray();
                    for (int i = 0; i < elementsToRemove.Length; i++)
                    {
                        removeFilter.Add(elementsToRemove[i]);
                        peoples.Remove(elementsToRemove[i]);
                    }
                    break;
                case "Contains":
                    elementsToRemove = peoples.Where(p => p.Contains(filterParamater)).ToArray();
                    for (int i = 0; i < elementsToRemove.Length; i++)
                    {
                        removeFilter.Add(elementsToRemove[i]);
                        peoples.Remove(elementsToRemove[i]);
                    }
                    break;
            }
        }
    }
}