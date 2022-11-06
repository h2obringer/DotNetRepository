using _841_KeysAndRooms;

Solution s = new Solution();

IList<IList<int>> test1 = new List<IList<int>>();
test1.Add(new List<int> { 1 });
test1.Add(new List<int> { 2 });
test1.Add(new List<int> { 3 });
test1.Add(new List<int> { });

Console.WriteLine($"Can visit all rooms: {s.CanVisitAllRooms(test1)}");
