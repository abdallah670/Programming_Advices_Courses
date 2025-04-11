using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
namespace C22_DS
{
    public class Collections
    {
        //Custom Object
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public Student(int id, string name, int age, string address)
            {
                Id = id;
                Name = name;
                Age = age;
                Address = address;
            }
        }
        //Generic Collections
        //List<T>
        private static void PrintList<T>(List<T> list)
        {
            // Print the list
            Console.Write("[");

            Console.Write(string.Join(",", list));

            Console.WriteLine("]");
        }
        public static void List()
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            Console.WriteLine("List of numbers:");
            PrintList(numbers);
            Console.WriteLine("Count of numbers: " + numbers.Count);
            Console.WriteLine("Capacity of numbers: " + numbers.Capacity);
            Console.WriteLine("Index of 3: " + numbers.IndexOf(3));
            numbers[1] = 10; // Changing the value at index 1
            Console.WriteLine("After Changing index 1:");
            PrintList(numbers);
            Console.WriteLine("After removing 3:");
            numbers.Remove(3);
            PrintList(numbers);
            Console.WriteLine("After inserting 20 at index 2:");
            numbers.Insert(2, 20);
            PrintList(numbers);
            numbers.InsertRange(2, new List<int> { 30, 40, 50 });
            Console.WriteLine("After inserting range at index 2:");
            PrintList(numbers);
            //Removing from the list
            numbers.RemoveAt(2);
            Console.WriteLine("After removing at index 2:");
            PrintList(numbers);
            numbers.RemoveRange(2, 3);
            Console.WriteLine("After removing range at index 2:");
            PrintList(numbers);
            numbers.RemoveAll(x => x < 10);
            Console.WriteLine("After removing all greater than 10:");
            PrintList(numbers);
            //Print the list with lambda
            Console.Write("List with lambda:");
            Console.Write("[");
            numbers.ForEach(x => Console.Write(x + ","));
            Console.WriteLine("]");
            //Using LINQ
            var evenNumbers = numbers.Where(x => x % 2 == 0);
            Console.Write("Even numbers:");
            Console.Write("[");
            foreach (var number in evenNumbers)
            {
                Console.Write(number + ",");
            }
            Console.WriteLine("]");
            //Aggregate function
            var sum = numbers.Aggregate((x, y) => x + y);
            Console.WriteLine("Sum of numbers: " + sum);
            Console.WriteLine(
                "Max of numbers: " + numbers.Max() + "\nMin of numbers: " + numbers.Min() + "\nAverage of numbers: " + numbers.Average());
            //Linq filter
            Console.WriteLine("Numbers greater than 10:");
            var greaterThan10 = from number in numbers
                                where number > 10
                                select number;
            PrintList(greaterThan10.ToList());
            //Sorting the list
            var sortedList = numbers.OrderBy(x => x);
            Console.WriteLine("Sorted list:");
            PrintList(sortedList.ToList());
            //Sorting the list in descending order
            var sortedListDesc = numbers.OrderByDescending(x => x);
            Console.WriteLine("Sorted list in descending order:");
            PrintList(sortedListDesc.ToList());
            //Sorting the list in ascending order
            numbers.Sort();
            Console.WriteLine("Sorted list in ascending order:");
            PrintList(numbers);
            //Sorting the list in descending order
            numbers.Sort((x, y) => y.CompareTo(x));
            Console.WriteLine("Sorted list in descending order:");
            PrintList(numbers);
            //Sorting in reverse order
            numbers.Reverse();
            Console.WriteLine("Reversed list:");
            PrintList(numbers);
            //Some other methods
            numbers.AddRange(new List<int> { 1, 2, 3, 4, 5 });
            Console.WriteLine("After adding range:");
            PrintList(numbers);
            Console.WriteLine("Is list containing 9: " + numbers.Contains(9));
            Console.WriteLine("Is list containing 1: " + numbers.Contains(1));
            Console.WriteLine("Is list contains negative Numbers: " + numbers.Exists(n => n < 0));
            Console.WriteLine("First number greater than 10: " + numbers.Find(n => n > 10));
            Console.WriteLine("All numbers greater than 10:" + string.Join(",", numbers.FindAll(n => n > 10)));
            Console.WriteLine("Any number greater than 10: " + numbers.Any(n => n > 10));
            //List of strings
            List<string> names = new List<string>();
            names.Add("John");
            names.Add("Jane");
            names.Add("Jack");
            names.Add("Jill");
            Console.WriteLine("List of names:");
            PrintList(names);
            Console.WriteLine("Count of names: " + names.Count);
            Console.WriteLine("Capacity of names: " + names.Capacity);
            Console.WriteLine("Index of Jane: " + names.IndexOf("Jane"));
            names[1] = "Mary"; // Changing the value at index 1
            Console.WriteLine("After Changing index 1:");
            //Some other methods
            names.AddRange(new List<string> { "John", "Jane", "Jack", "Jill" });
            Console.WriteLine("After adding range:");
            PrintList(names);
            Console.WriteLine("Is list containing John: " + names.Contains("John"));
            Console.WriteLine("Is list containing Mary: " + names.Contains("Mary"));
            Console.WriteLine("Is list contains empty names: " + names.Exists(n => n == ""));
            Console.WriteLine("First name starting with J: " + names.Find(n => n.StartsWith("J")));
            Console.WriteLine("All names starting with J:" + string.Join(",", names.FindAll(n => n.StartsWith("J"))));
            Console.WriteLine("Any name starting with J: " + names.Any(n => n.StartsWith("J")));
            Console.WriteLine("any name Ending with e: " + names.Any(n => n.EndsWith("e")));
            //List of custom objects
            List<Student> students = new List<Student>();
            students.Add(new Student(1, "John", 20, "New York"));
            students.Add(new Student(2, "Jane", 22, "Los Angeles"));
            students.Add(new Student(3, "Jack", 21, "Chicago"));
            students.Add(new Student(4, "Jill", 23, "Houston"));
            Console.WriteLine("List of students:");
            foreach (var student in students)
            {
                Console.WriteLine("Id: " + student.Id + ", Name: " + student.Name + ", Age: " + student.Age + ", Address: " + student.Address);
            }
            //Using find and update
            var studentToFind = students.Find(s => s.Id == 2);
            if (studentToFind != null)
            {
                Console.WriteLine("Found student with Id 2: " + studentToFind.Name);
            }
            else
            {
                Console.WriteLine("Student with Id 2 not found");
            }
            var studentToUpdate = students.Find(s => s.Id == 2);
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = "Mary";
                studentToUpdate.Age = 25;
                studentToUpdate.Address = "San Francisco";
            }
            Console.WriteLine("After updating student with Id 2:");
            foreach (var student in students)
            {
                Console.WriteLine("Id: " + student.Id + ", Name: " + student.Name + ", Age: " + student.Age + ", Address: " + student.Address);
            }
            //Using remove and clear
            var studentToRemove = students.Find(s => s.Id == 2);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                Console.WriteLine("Removed student with Id 2");
            }
            else
            {
                Console.WriteLine("Student with Id 2 not found");
            }
            Console.WriteLine("After removing student with Id 2:");
            foreach (var student in students)
            {
                Console.WriteLine("Id: " + student.Id + ", Name: " + student.Name + ", Age: " + student.Age + ", Address: " + student.Address);
            }
            //Using LINQ
            Student stud = students.FirstOrDefault(s => s.Id == 1);
            if (stud != null)
            {
                Console.WriteLine("Found student with Id 1: " + stud.Name);
            }
            else
            {
                Console.WriteLine("Student with Id 1 not found");
            }
            //Findall students with age greater than 21
            var studentsWithAgeGreaterThan21 = students.Where(s => s.Age > 21);
            Console.WriteLine("Students with age greater than 21:");
            foreach (var student in studentsWithAgeGreaterThan21)
            {
                Console.WriteLine("Id: " + student.Id + ", Name: " + student.Name + ", Age: " + student.Age + ", Address: " + student.Address);
            }
            //To array
            Student[] studentsArray = students.ToArray();
            Console.WriteLine("Students array:");
            foreach (var student in studentsArray)
            {
                Console.WriteLine("Id: " + student.Id + ", Name: " + student.Name + ", Age: " + student.Age + ", Address: " + student.Address);
            }
            int[] numbersArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> numbersList = new List<int>(numbersArray);
            Console.WriteLine("Numbers list:");
            foreach (var number in numbersList)
            {
                Console.WriteLine(number);
            }
        }
        //HashSet<T>
        public static void HashSet()
        {
            HashSet<int> numbers = new HashSet<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            Console.WriteLine("HashSet of numbers:");
            PrintList(numbers.ToList());
            Console.WriteLine("Count of numbers: " + numbers.Count);
            Console.WriteLine("Is HashSet contains 3: " + numbers.Contains(3));
            Console.WriteLine("Is HashSet contains 10: " + numbers.Contains(10));
            //Removing from the HashSet
            numbers.Remove(3);
            Console.WriteLine("After removing 3:");
            PrintList(numbers.ToList());
            //Modifying the value
            //HashSet does not support modifying the value, so we need to remove and add again
            numbers.Remove(2);
            numbers.Add(20);
            Console.WriteLine("After modifying 2:");
            PrintList(numbers.ToList());
            //Using LINQ
            Console.Write("contains 2: " + numbers.Contains(2));
            //Array to HashSet
            int[] numbersArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            HashSet<int> numbersHashSet = new HashSet<int>(numbersArray);
            Console.WriteLine("HashSet from array:");
            PrintList(numbersHashSet.ToList());
            var evenNumbers = numbersHashSet.Where(x => x % 2 == 0);
            Console.WriteLine(
                "Even numbers from HashSet:");
            PrintList(evenNumbers.ToList());
            //Union
            HashSet<int> numbersHashSet2 = new HashSet<int>();
            numbersHashSet2.Add(6);
            numbersHashSet2.Add(7);
            numbersHashSet2.Add(8);
            numbersHashSet2.Add(9);
            numbersHashSet2.Add(10);
            Console.WriteLine("HashSet 2:");
            PrintList(numbersHashSet2.ToList());
            numbersHashSet.UnionWith(numbersHashSet2);
            Console.WriteLine("After Union with HashSet 2:");
            PrintList(numbersHashSet.ToList());
            //Intersection
            HashSet<int> numbersHashSet3 = new HashSet<int>();
            numbersHashSet3.Add(1);
            numbersHashSet3.Add(2);
            numbersHashSet3.Add(3);
            numbersHashSet3.Add(4);
            numbersHashSet3.Add(5);
            Console.WriteLine("HashSet 3:");
            PrintList(numbersHashSet3.ToList());
            numbersHashSet.IntersectWith(numbersHashSet3);
            Console.WriteLine("After Intersection with HashSet 3:");
            PrintList(numbersHashSet.ToList());
            //Difference
            HashSet<int> numbersHashSet4 = new HashSet<int>();
            numbersHashSet4.Add(1);
            numbersHashSet4.Add(2);

            numbersHashSet4.UnionWith(numbersHashSet4);
            numbersHashSet4.Add(5);
            Console.WriteLine("HashSet 4:");
            PrintList(numbersHashSet4.ToList());
            numbersHashSet.ExceptWith(numbersHashSet4);
            Console.WriteLine("After Difference with HashSet 4:");
            PrintList(numbersHashSet.ToList());
            //Symmetric Difference
            numbersHashSet.SymmetricExceptWith(numbersHashSet4);
            Console.WriteLine("After Symmetric Difference with HashSet 4:");
            PrintList(numbersHashSet.ToList());
            //Comparing HashSets
            HashSet<int> numbersHashSet5 = new HashSet<int>();
            numbersHashSet5.Add(1);
            numbersHashSet5.Add(2);

            numbersHashSet5.Add(3);
            numbersHashSet5.Add(4);
            numbersHashSet5.Add(5);
            Console.WriteLine("HashSet 5:");
            PrintList(numbersHashSet5.ToList());
            Console.WriteLine("HashSet 5 is equal to HashSet 1: " + numbersHashSet.SetEquals(numbersHashSet5));
            Console.WriteLine("HashSet 5 is equal to HashSet 2: " + numbersHashSet.SetEquals(numbersHashSet2));
            Console.WriteLine("Hashset 5 is subset of HashSet 1: " + numbersHashSet.IsSubsetOf(numbersHashSet5));
            Console.WriteLine("Hashset 5 is superset of HashSet 1: " + numbersHashSet5.IsSupersetOf(numbersHashSet));
            Console.WriteLine("Hashset 5 is proper subset of HashSet 1: " + numbersHashSet.IsProperSubsetOf(numbersHashSet5));
            //Overlapping
            Console.WriteLine(
                "Hashset 5 Overlaps HashSet 1: " + numbersHashSet5.Overlaps(numbersHashSet));



        }
        //Dictionary<TKey, TValue>
        public static void Dictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("John", 1);
            dictionary.Add("Jane", 2);
            dictionary.Add("Jack", 3);
            dictionary.Add("Jill", 4);
            Console.WriteLine("Dictionary:");
            foreach (KeyValuePair<string, int> entry in dictionary)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            Console.WriteLine("Count of Dictionary: " + dictionary.Count);
            Console.WriteLine("Is Dictionary contains John: " + dictionary.ContainsKey("John"));
            Console.WriteLine("Is Dictionary contains 10: " + dictionary.ContainsValue(10));
            //Removing from the Dictionary
            dictionary.Remove("John");
            Console.WriteLine("After removing John:");
            foreach (KeyValuePair<string, int> entry in dictionary)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            //Modifying the value
            dictionary["Jane"] = 5;
            Console.WriteLine("After modifying Jane:");
            foreach (KeyValuePair<string, int> entry in dictionary)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            //Uisng trygetvalue
            int value;
            if (dictionary.TryGetValue("Jack", out value))
            {
                Console.WriteLine("Jack's value: " + value);
            }
            else
            {
                Console.WriteLine("Jack not found");
            }
            //Using LINQ
            var dictionaryinfo = dictionary.Select(x => new { x.Key, x.Value });
            Console.WriteLine("Dictionary info:");
            foreach (var entry in dictionaryinfo)
            {
                Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            }
            //Using LINQ to filter
            var filteredDictionary = dictionary.Where(x => x.Value > 2);
            Console.WriteLine("Filtered Dictionary:");
            foreach (var entry in filteredDictionary)
            {
                Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            }
            //Using LINQ to sort
            var sortedDictionary = dictionary.OrderBy(x => x.Key);
            Console.WriteLine("Sorted Dictionary:");
            foreach (var entry in sortedDictionary)
            {
                Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            }
            //Aggregate function
            var sum = dictionary.Aggregate((x, y) => new KeyValuePair<string, int>(x.Key, x.Value + y.Value));
            Console.WriteLine("Sum of Dictionary values: " + sum.Value);
            //Advanced LINQ
            Dictionary<string, string> fruitsCategory = new Dictionary<string, string>
                    {
                        { "Apple", "Tree" },
                        { "Banana", "Herb" },
                        { "Cherry", "Tree" },
                        { "Strawberry", "Bush" },
                        { "Raspberry", "Bush" }
                    };
            var groupedFruits = fruitsCategory.GroupBy(kpv => kpv.Value);
            Console.WriteLine("Grouped Fruits:");

            foreach (var group in groupedFruits)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var fruit in group)
                {
                    Console.WriteLine($" - {fruit.Key}");
                }
            }
            //Using LINQ to join two dictionaries
            Dictionary<string, string> colors = new Dictionary<string, string>
                    {
                        { "Apple", "Red" },
                        { "Banana", "Yellow" },
                        { "Cherry", "Red" },
                        { "Strawberry", "Red" },
                        { "Raspberry", "Red" }
                    };

            var joinedDictionaries = from fruit in fruitsCategory
                                     join color in colors on fruit.Key equals color.Key
                                     select new { Fruit = fruit.Key, Category = fruit.Value, Color = color.Value };

            Console.WriteLine("Joined Dictionaries:");
            foreach (var entry in joinedDictionaries)
            {
                Console.WriteLine($"Fruit: {entry.Fruit}, Category: {entry.Category}, Color: {entry.Color}");
            }










        }
        //SortedList<TKey, TValue>
        public static void SortedList()
        {
            SortedList<string, int> sortedList = new SortedList<string, int>();
            sortedList.Add("John", 1);
            sortedList.Add("Jane", 2);
            sortedList.Add("Jack", 3);
            sortedList.Add("Jill", 4);
            Console.WriteLine("SortedList:");
            foreach (KeyValuePair<string, int> entry in sortedList)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            Console.WriteLine("Count of SortedList: " + sortedList.Count);
            Console.WriteLine("Is SortedList contains John: " + sortedList.ContainsKey("John"));
            Console.WriteLine("Is SortedList contains 10: " + sortedList.ContainsValue(10));
            //Removing from the SortedList
            sortedList.Remove("John");
            Console.WriteLine("After removing John:");
            foreach (KeyValuePair<string, int> entry in sortedList)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
        }
        //Sorted Set<T>
        public static void SortedSet()
        {
            SortedSet<int> sortedSet = new SortedSet<int>();
            sortedSet.Add(5);
            sortedSet.Add(2);
            sortedSet.Add(8);
            sortedSet.Add(4);
            Console.WriteLine("SortedSet:");
            PrintList(sortedSet.ToList());
            Console.WriteLine("Count of SortedSet: " + sortedSet.Count);
            Console.WriteLine("Is SortedSet contains 3: " + sortedSet.Contains(3));
            Console.WriteLine("Is SortedSet contains 10: " + sortedSet.Contains(10));
            //Removing from the SortedSet
            sortedSet.Remove(2);
            Console.WriteLine("After removing 2:");
            PrintList(sortedSet.ToList());
            sortedSet = new SortedSet<int>() { 1, 2, 3, 4, 5 };
            // Filtering elements greater than 2
            var filteredSet = sortedSet.Where(x => x > 2);
            Console.WriteLine("Filtered Set:");
            foreach (var item in filteredSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            // Sum of all elements
            var sum = sortedSet.Sum();
            Console.WriteLine("Sum of all elements: " + sum);


            // Maximum and minimum elements
            var maxElement = sortedSet.Max();
            var minElement = sortedSet.Min();
            Console.WriteLine("Maximum element: " + maxElement);
            Console.WriteLine("Minimum element: " + minElement);


            // Sorting the set in descending order
            var descendingSet = sortedSet.OrderByDescending(x => x);
            Console.WriteLine("Descending Sorted Set:");
            foreach (var item in descendingSet)
            {
                Console.Write(item + " ");
            }
            SortedSet<int> numbers = new SortedSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Find even numbers and project them to their square
            var evenNumbersSquared = numbers.Where(x => x % 2 == 0).Select(x => x * x);
            Console.WriteLine("Squares of even numbers:");
            foreach (var item in evenNumbersSquared)
            {
                Console.Write(item + " ");
            }
            SortedSet<int> set1 = new SortedSet<int>() { 1, 2, 3, 4, 5 };
            SortedSet<int> set2 = new SortedSet<int>() { 3, 4, 5, 6, 7 };


            // Union
            SortedSet<int> unionSet = new SortedSet<int>(set1);
            unionSet.UnionWith(set2);
            Console.WriteLine("\nUnion:");
            foreach (int item in unionSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            // Intersection
            SortedSet<int> intersectSet = new SortedSet<int>(set1);
            intersectSet.IntersectWith(set2);
            Console.WriteLine("\nIntersection:");
            foreach (int item in intersectSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            // Difference
            SortedSet<int> differenceSet = new SortedSet<int>(set1);
            differenceSet.ExceptWith(set2);
            Console.WriteLine("\nDifference (set1 - set2):");
            foreach (int item in differenceSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            // Subset and Superset
            Console.WriteLine("\nSubset:");
            if (set1.IsSubsetOf(set2))
                Console.WriteLine("Set1 is a subset of Set2");
            else
                Console.WriteLine("Set1 is not a subset of Set2");


            Console.WriteLine("\nSuperset:");
            if (set1.IsSupersetOf(set2))
                Console.WriteLine("Set1 is a superset of Set2");
            else
                Console.WriteLine("Set1 is not a superset of Set2");
        }
        //Non-Generic Collections
        //ArrayList
        public static void ArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("John");
            arrayList.Add(2.5);
            arrayList.Add(true);
            Console.WriteLine("ArrayList:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Count of ArrayList: " + arrayList.Count);
            Console.WriteLine("Capacity of ArrayList: " + arrayList.Capacity);
            Console.WriteLine("Index of John: " + arrayList.IndexOf("John"));
            //Removing from the ArrayList
            arrayList.Remove(1);
            Console.WriteLine("After removing 1:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
        //Hashtable
        public static void HashTable()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("John", 1);
            hashtable.Add("Jane", 2);
            hashtable.Add("Jack", 3);
            hashtable.Add("Jill", 4);
            Console.WriteLine("Hashtable:");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            Console.WriteLine("Count of Hashtable: " + hashtable.Count);
            Console.WriteLine("Is Hashtable contains John: " + hashtable.ContainsKey("John"));
            Console.WriteLine("Is Hashtable contains 10: " + hashtable.ContainsValue(10));
            //Removing from the Hashtable
            hashtable.Remove("John");
            Console.WriteLine("After removing John:");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            //Modifying the value
            hashtable["Jane"] = 5;
            Console.WriteLine("After modifying Jane:");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
        }

        //Collections interfaces
        public class CustomCollection<T> : IEnumerable<T>
        {
            private List<T> items = new List<T>();


            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < items.Count; i++)
                {
                    yield return items[i];
                }
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }


            public void Add(T item)
            {
                items.Add(item);
            }
        }
        public void DisplayIEnumerator()
        {
            CustomCollection<int> collection = new CustomCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);
            Console.WriteLine("Custom Collection:");
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
        public class SimpleCollection<T> : ICollection<T>
        {
            private List<T> items = new List<T>();


            public int Count => items.Count;


            public bool IsReadOnly => false;


            public void Add(T item)
            {
                items.Add(item);
            }


            public void Clear()
            {
                items.Clear();
            }


            public bool Contains(T item)
            {
                return items.Contains(item);
            }


            public void CopyTo(T[] array, int arrayIndex)
            {
                items.CopyTo(array, arrayIndex);
            }


            public bool Remove(T item)
            {
                return items.Remove(item);
            }


            public IEnumerator<T> GetEnumerator()
            {
                return items.GetEnumerator();
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        public void DisplayICollection()
        {
            SimpleCollection<string> shoppingCart = new SimpleCollection<string>();
            shoppingCart.Add("Apple");
            shoppingCart.Add("Banana");
            shoppingCart.Add("Carrot");


            Console.WriteLine($"Items in cart: {shoppingCart.Count}");

            if (shoppingCart.Contains("Banana"))
            {
                shoppingCart.Remove("Banana");
                Console.WriteLine("Banana removed from the cart.");
            }


            Console.WriteLine("Final items in the cart:");
            foreach (var item in shoppingCart)
            {
                Console.WriteLine(item);
            }

        }
        public class SimpleList<T> : IList<T>
        {
            private List<T> _items = new List<T>();


            public T this[int index]
            {
                get => _items[index];
                set => _items[index] = value;
            }


            public int Count => _items.Count;
            public bool IsReadOnly => false;


            public void Add(T item) => _items.Add(item);
            public void Clear() => _items.Clear();
            public bool Contains(T item) => _items.Contains(item);
            public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
            public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
            public int IndexOf(T item) => _items.IndexOf(item);
            public void Insert(int index, T item) => _items.Insert(index, item);
            public bool Remove(T item) => _items.Remove(item);
            public void RemoveAt(int index) => _items.RemoveAt(index);


            IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
        }
        public void DisplayIList()
        {
            SimpleList<string> shoppingList = new SimpleList<string>();
            shoppingList.Add("Milk");
            shoppingList.Add("Eggs");
            shoppingList.Add("Bread");

            shoppingList.Insert(1, "Butter");
            Console.WriteLine("Shopping List:");
            foreach (var item in shoppingList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Item at index 1: {shoppingList[1]}");
            shoppingList.RemoveAt(2);
            Console.WriteLine(
                "After removing item at index 2:");
            foreach (var item in shoppingList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Count: {shoppingList.Count}");
            Console.WriteLine($"Contains 'Eggs': {shoppingList.Contains("Eggs")}");
            Console.WriteLine($"Index of 'Milk': {shoppingList.IndexOf("Milk")}");
            Console.WriteLine(
                $"Is ReadOnly: {shoppingList.IsReadOnly}");
            Console.WriteLine(
                $"Item at index 1: {shoppingList[1]}");
            shoppingList[1] = "Cheese";
            Console.WriteLine(
                $"After updating item at index 1:");
            Console.WriteLine(
                $"Item at index 1: {shoppingList[1]}");
        }
        public class SimpleDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        {
            private List<KeyValuePair<TKey, TValue>> _list = new List<KeyValuePair<TKey, TValue>>();


            public TValue this[TKey key]
            {
                get
                {
                    foreach (var kvp in _list)
                    {
                        if (Equals(kvp.Key, key))
                        {
                            return kvp.Value;
                        }
                    }
                    throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary.");
                }
                set
                {
                    bool found = false;
                    for (int i = 0; i < _list.Count; i++)
                    {
                        if (Equals(_list[i].Key, key))
                        {
                            _list[i] = new KeyValuePair<TKey, TValue>(key, value);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        _list.Add(new KeyValuePair<TKey, TValue>(key, value));
                    }
                }
            }


            public ICollection<TKey> Keys => _list.ConvertAll(kvp => kvp.Key);


            public ICollection<TValue> Values => _list.ConvertAll(kvp => kvp.Value);


            public int Count => _list.Count;


            public bool IsReadOnly => false;


            public void Add(TKey key, TValue value)
            {
                foreach (var kvp in _list)
                {
                    if (Equals(kvp.Key, key))
                    {
                        throw new ArgumentException("An element with the same key already exists.");
                    }
                }
                _list.Add(new KeyValuePair<TKey, TValue>(key, value));
            }


            public void Add(KeyValuePair<TKey, TValue> item)
            {
                Add(item.Key, item.Value);
            }


            public void Clear()
            {
                _list.Clear();
            }


            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                return _list.Contains(item);
            }


            public bool ContainsKey(TKey key)
            {
                foreach (var kvp in _list)
                {
                    if (Equals(kvp.Key, key))
                    {
                        return true;
                    }
                }
                return false;
            }


            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                _list.CopyTo(array, arrayIndex);
            }


            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                return _list.GetEnumerator();
            }


            public bool Remove(TKey key)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    if (Equals(_list[i].Key, key))
                    {
                        _list.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }


            public bool Remove(KeyValuePair<TKey, TValue> item)
            {
                return _list.Remove(item);
            }


            public bool TryGetValue(TKey key, out TValue value)
            {
                foreach (var kvp in _list)
                {
                    if (Equals(kvp.Key, key))
                    {
                        value = kvp.Value;
                        return true;
                    }
                }
                value = default;
                return false;
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return _list.GetEnumerator();
            }
        }

        public void DisplayIDictionary()
        {
            SimpleDictionary<string, int> dictionary = new SimpleDictionary<string, int>();
            dictionary.Add("John", 1);
            dictionary.Add("Jane", 2);
            dictionary.Add("Jack", 3);
            Console.WriteLine("Simple Dictionary:");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"Count: {dictionary.Count}");
            Console.WriteLine($"Contains 'Jane': {dictionary.ContainsKey("Jane")}");
            Console.WriteLine($"Value for 'Jack': {dictionary["Jack"]}");
            dictionary["Jack"] = 5;
            Console.WriteLine($"Updated value for 'Jack': {dictionary["Jack"]}");
            dictionary.Remove("Jane");
            Console.WriteLine("After removing 'Jane':");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
        public class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }


            // Implementing the CompareTo method for Person class
            public int CompareTo(Person other)
            {
                // If other is not a valid object reference, this instance is greater.
                if (other == null) return 1;


                // Use the Age property to determine the order of Person instances.
                return this.Age.CompareTo(other.Age);
            }


            // Constructor for easier initialization
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }


            // Override ToString to make output easier to read
            public override string ToString()
            {
                return $"{Name}, {Age} years old";
            }
        }
        public void DisplayIComparable()
        {
            List<Person> people = new List<Person> {


            new Person("John", 30),
            new Person("Jane", 25),
            new Person("Doe", 28),
            };
        


            // Sorting the list using IComparable implementation
            people.Sort();


            // Printing the sorted list
            Console.WriteLine("People sorted by age:");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
