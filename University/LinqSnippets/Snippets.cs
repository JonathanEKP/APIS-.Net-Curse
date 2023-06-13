using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LinqSnippets
{
    public class Snippets
    {

        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            //1. SELECT * of cars
            var carList = from car in cars select car;
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }


            //2. SELECT WHERE car is audi
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }

        }

        //Number Examples
        static public void LinqNumers()
        {
            List<int> numbers = new List<int> { 1, 2, 4, 5, 6, 7, 9 };

            //Each Number multiplied by 3
            //Take all numbers, but 9
            //Order numbers by ascending value
            var processedNumberList =
                numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);

        }


        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            //1. First of all elements
            var first = textList.First();

            //2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            //3. First element that contains "J"
            var jText = textList.First(text => text.Contains("j"));

            //4. First element that contains z or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z")); // "" or first element that contains "z"

            //5. Last element thath contains z or defualt
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z")); //"" or last element that contains "z"

            //6. Single value
            var uniqueText = textList.Single();
            var uniqueOrDefaultText = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //Obtain {4, 8}
            var myEvenNumers = evenNumbers.Except(otherEvenNumbers); //{4. 8}

        }

        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"

            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));


            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "martin@imaginagroup.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "pepe@imaginagroup.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Juanjo",
                            Email = "juanjo@imaginagroup.com",
                            Salary = 2000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "ana",
                            Email = "ana@imaginagroup.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "maria@imaginagroup.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "marta@imaginagroup.com",
                            Salary = 4000
                        }
                    }
                }
            };

            //Obtain all employees of all enterprises
            var employeeList = enterprises.SelectMany(enterprises => enterprises.Employees);

            //Know if any list is empty
            bool hasEnterprise = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprises => enterprises.Employees.Any());

            // All enterprises at least has an employees with at leas 1000
            bool hasEmployeeWithSalaryMoreOrEqual1000 =
                enterprises.Any(enterprises =>
                    enterprises.Employees.Any(employees => employees.Salary >= 1000));


        }

        static public void LinqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new { element, secondElement }
                );

            //OUTTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };
            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };


            //OUTTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }


        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10
            };

            var skipTwoFirstElements = myList.Skip(2); // {3,4,5,6,7,8,9,10}

            var skipLastTwoValues = myList.SkipLast(2); // {1,2,3,4,5,6,7,8}

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4); // {4,5,6,7,8,9,10}

            //TAKE
            var takeFirstTwoValues = myList.Take(2); // {1,2}

            var takeLastTwoValues = myList.TakeLast(2); //{9,10}

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num <= 4); // {1,2,3,}
        }

        //TODO:

        //Paggin with skip & take
        public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        //VARIABLES
        static public void linQVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Average: {0}", numbers.Average());

            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Query: {0} {1}", number, Math.Pow(number, 2));
            }
        }


        //ZIP 
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) =>
            number + "=" + word);
            //{1="one". 2="two", ...} 
        }


        // REPEAT & RANGE
        static public void repeatRangeLinq()
        {
            //Generate collection from 1 to 1000 --> Range
            var first1000 = Enumerable.Range(0, 1000);

            //Repeat a valuea n Times
            var fiveXs = Enumerable.Repeat("X", 5); // XXXXX
        }

        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student()
                {
                    Id = 1,
                    Name = "Jonathan",
                    Grade = 90,
                    Certified = true,
                },
                new Student()
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student()
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 95,
                    Certified = true,
                },
                new Student()
                {
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student()
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = false,
                },
            };

            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var approvedStudentsNames = from student in classRoom
                                        where student.Grade >= 50 && student.Certified == true
                                        select student.Name;
        }

        //ALL
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); //true
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); //false

            var emptyList = new List<int>();

            bool allNumberAreGraterThan0 = numbers.All(x => x >= 0); //true
        }

        //AGREGATE 
        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            string[] words = { "Hello", "My", "Name", "Is", "Jonathan" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);


        }

        //DISCTINCT 
        static public void distincValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };
            IEnumerable<int> distinctValues = numbers.Distinct();
        }


        //GROUP BY
        static public void groupByExample()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // We will have two groups
            //1. the group that doesn't fit the condition
            //2. the group that fits the condition


            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 ... 2,4,6,8 (first odds and then even)

                }
            }

            var classRoom = new[]
            {
                new Student()
                {
                    Id = 1,
                    Name = "Jonathan",
                    Grade = 90,
                    Certified = true,
                },
                new Student()
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student()
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 95,
                    Certified = true,
                },
                new Student()
                {
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student()
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = false,
                },
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified);
            // We obtain two groups
            //1. Not certefied students
            //2. Certified students
            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("--------- {0} ------ ", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name); 

                }
            }

        }

        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id =1,
                    Title = "My Fist Post",
                    Content = "My first content",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second comment",
                            Content = "My other content"
                        },
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "My second Post",
                    Content = "My second content",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My other comment",
                            Content = "My new content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My other new comment",
                            Content = "My other content"
                        },
                    }
                }
            };

            var commentsWithContent = posts.SelectMany(post => post.Comments,
                (post, comment) => 
                new { PostId = post.Id, Commentcontent = comment.Content });




        }
    }
}