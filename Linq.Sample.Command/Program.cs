using Dumpify;

    IEnumerable<int> numbers = Enumerable.Range(1, 8);
    IEnumerable<int> sequenceOne = [1, 2, 3];
    IEnumerable<int> sequenceTwo = [1, 2, 3];
    IEnumerable<int> sequenceThree = [1, 2, 3, 4];

// Filtering
// WHERE
// Numbers

numbers.Where(x => x > 2).Dump("Where");

// Objects
    IEnumerable<object> types = [1, "This", 2, "is", 3, "a", 4, "string", 5];
    types.OfType<int>().Dump("OfType<int>");
    types.OfType<string>().Dump("OfType<string>");

// Partitioning

    // Skip
    numbers.Skip(3).Dump("Skip");

    // Take
    numbers.Take(3).Dump("Take");

    // SkipLast
    numbers.SkipLast(3).Dump("SkipLast");

    // TakeLast
    numbers.TakeLast(3).Dump("TakeLast");

    // SkipWhile -> Runs until the predicate is wrong
    numbers.SkipWhile(x => x < 3).Dump("SkipWhile");

    // TakeWhile -> Runs until the predicate is wrong
    numbers.TakeWhile(x => x < 3).Dump("TakeWhile");

// Projection

    // Select
    numbers.Select(x => x).Dump("Select");
    // Select with index
    numbers.Select((x, i) => $"{i}: {x}").Dump("Select with index");

    // SelectMany
    IEnumerable<List<int>> nestedNumbers = [[1, 2, 3], [4, 5, 6]];
    nestedNumbers.SelectMany(x => x.Select(x => x.ToString())).Dump("SelectMany");
    nestedNumbers.SelectMany((x, i) => x.Select(x => $"{i}: {x}".ToString())).Dump("SelectMany with index");

    // Cast
    IEnumerable<object> numbersToCast = [1, 2, 3, 4, 5];
    numbersToCast.Cast<int>().Dump("Cast");

    // Chunk
    IEnumerable<int> numbersToChunk = Enumerable.Range(1, 8);
    numbersToChunk.Chunk(3).Dump("Chunk");

// Existence or quantity checks (bool)

    // Any
    numbers.Any(x => x > 2).Dump("Any");

    // All
    numbers.All(x => x > 1).Dump("All");

    // Contains
    numbers.Contains(3).Dump("Contains");

// Sequence Manipulation

    // Append 
    numbers.Append(9).Dump("Append");
    // Prepend
    numbers.Prepend(0).Dump("Prepend");

// Aggregation Methods
    // Count
    numbers.Count().Dump("Count");

    // TryGetNonEnumeratedCount    
    numbers.TryGetNonEnumeratedCount(out int count).Dump("TryGetNonEnumeratedCount");

    // Max
    numbers.Max().Dump("Max");

    // MaxBy
    numbers.MaxBy(x => x * -1).Dump("MaxBy");

    IEnumerable<Person> persons = [new(0, "You", 15), new(1, "Me", 16), new(2, "Them", 15)];
    persons.MaxBy(x => x.Age).Dump("MaxBy Age");

    // Min similar to Max

    // Sum
    numbers.Sum().Dump("Sum");

    // Average
    numbers.Average().Dump("Average");

    // Aggregate
    numbers.Aggregate((x, y) => x + y).Dump("Aggregate Sum");

    numbers.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}").Dump("Aggregate Join");
    numbers.Aggregate(10, (x, y) => x + y).Dump("Aggregate Sum + 10");
    numbers.Aggregate(0, (x, y) => x + y, x => (float)x / numbers.Count()).Dump("Aggregate Average");

    // LongCount similar to Count but returns long

// Element Operator
    // First
    numbers.First().Dump("First");

    // FirstOrDefault
    numbers.FirstOrDefault(-1).Dump("FirstOrDefault");

    // Single / SingleOrDefault expects just one Element, otherwise it will throw an exception!

    // Last / LastOrDefault similar to First / FirstOrDefault

    // ElementAt
    numbers.ElementAt(2).Dump("ElementAt");

    // ElementAtOrDefault
    numbers.ElementAtOrDefault(99).Dump("ElementAtOrDefault");

    // DefaultIfEmpty
    IEnumerable<int> emptyNumbers = [];
    emptyNumbers.DefaultIfEmpty().Dump("DefaultIfEmpty");

// Conversion Methods
    // ToArray
    numbers.ToArray().Dump("ToArray");

    // ToList
    numbers.ToList().Dump("ToList");

    // ToDictionary
    numbers.ToDictionary(key => key, value => value).Dump("ToDictionary");

    // ToHashSet
    numbers.ToHashSet().Dump("ToHashSet");

    // ToLookup
    persons.ToLookup(x => x.Age).Dump("ToLookup");
    persons.ToLookup(x => x.Age)[16].Single().Name.Dump("ToLookup");

// Generation Methods
    // AsEnumerable
    numbers.AsEnumerable().Dump("AsEnumerable");

    // AsQueryable
    numbers.AsQueryable().Dump("AsEnumerable");

    // Range -> See creation of numbers

    // Repeat
    IEnumerable<int> repeatedNumers = Enumerable.Repeat(1, 5).Dump("Repeat");

    // Empty
    IEnumerable<int> alsoEmptyNumbers = Enumerable.Empty<int>();

// Set Operations
    // Distinct
    IEnumerable<int> variousNumbers = [1, 2, 3, 4, 1, 2];
    variousNumbers.Distinct().Dump("Distinct");

    // DistinctBy
    persons.DistinctBy(x => x.Age).Dump("DistinctBy");

    // Union
    IEnumerable<int> firstNumbers = [1, 2, 3, 4];
    IEnumerable<int> secondNumbers = [3, 4, 5, 6];

    firstNumbers.Union(secondNumbers).Dump("Union");

    // Intersect
    firstNumbers.Intersect(secondNumbers).Dump("Intersect");

    // Except
    firstNumbers.Except(secondNumbers).Dump("Except");

    // UnionBy
    IEnumerable<Person> firstPersons = [new(0, "You", 15), new(1, "Me", 16)];
    IEnumerable<Person> secondPersons = [new(0, "You", 15), new(3, "Them", 17)];

    firstPersons.UnionBy(secondPersons, x => x.Id).Dump("UnionBy");

    // IntersectBy
    firstPersons.IntersectBy(secondPersons.Select(x => x.Id), x => x.Id).Dump("IntersectBy");

    // ExceptBy
    firstPersons.ExceptBy(secondPersons.Select(x => x.Id), person => person.Id).Dump("ExceptBy");

    // SequenceEqual
    sequenceOne.SequenceEqual(sequenceTwo).Dump("SequenceEqual");
    sequenceOne.SequenceEqual(sequenceThree).Dump("SequenceEqual");

// Joining & Grouping
    // Zip
    IEnumerable<string> letters = ["a", "b", "c", "d", "e", "f", "g"];
    IEnumerable<string> marks = ["!", "?", "#", "%", "*"];

    numbers.Zip(letters).Dump("Zip");
    var zipped = numbers.Zip(letters, (number, letter) => (Number: number, Letter: letter)).Dump("Zip");

    foreach (var pair in zipped)
    {
        Console.WriteLine($"Number: {pair.Number}, Letter: {pair.Letter}");
    }

    numbers.Zip(letters).Dump("Zip");
    IEnumerable<(int Number, string Letter, string Mark)>? biggerZipped = numbers.Zip(letters, marks).Dump("Zip");

    // Join
    IEnumerable<Product> products = [new(0, "Shoes"), new(0, "Pants"), new(1, "Nothing because no money!"), new(2, "Glasses")];

    persons
        .Join(products, 
        person => person.Id, 
        product => product.PersonId, 
        (person, product) => $"{person.Name} bought {product.Name}")
        .Dump("Join");

    // GroupJoin
    persons
        .GroupJoin(products,
        person => person.Id,
        product => product.PersonId,
        (person, product) => $"{person.Name} bought {string.Join(',', products)}")
        .Dump("GroupJoin");

    // Concat
    sequenceOne.Concat(sequenceTwo).Dump("Concat");

    // GroupBy
    persons.GroupBy(x => x.Age).Dump("GroupBy");

// Sorting
    IEnumerable<int> unorderedNumbers = [5, 3, 4, 1, 2];
    IEnumerable<Person> unorderedPersons = [new(0, "You", 15), new(1, "Me", 16), new(1, "Them", 15)];

// Order
unorderedNumbers.Order().Dump("Order");

    // OrderDescending
    unorderedNumbers.OrderDescending().Dump("OrderDescending");

    // OrderBy
    unorderedPersons.OrderBy(x => x.Age).Dump("OrderBy");

    // OrderByDescending
    unorderedPersons.OrderByDescending(x => x.Age).Dump("OrderByDescending");

    // ThenBy
    unorderedPersons.OrderBy(x => x.Id).ThenBy(x => x.Age).Dump("ThenBy");

    // ThenByDescending
    unorderedPersons.OrderByDescending(x => x.Id).ThenByDescending(x => x.Age).Dump("ThenByDescending");

    // Reverse
    unorderedNumbers.Reverse().Dump("Reverse");

record Person(int Id, string Name, int Age);
record Product(int PersonId, string Name);