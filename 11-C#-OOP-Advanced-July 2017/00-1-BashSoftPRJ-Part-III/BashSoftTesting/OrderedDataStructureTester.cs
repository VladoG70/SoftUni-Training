using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Contracts;
using BashSoft.DataStructures;

namespace BashSoftTesting
    {
    [TestFixture]
    public class OrderedDataStructureTester
        {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void TestInitialize()
            {
            this.names = new SimpleSortedList<string>();
            }

        [Test]
        public void TestEmptyCtor()
            {
            //Assert
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
            }

        [Test]
        public void TestCtorWithInitialCapacity()
            {
            // Arrange & Acts
            this.names = new SimpleSortedList<string>(20);

            //Assert
            Assert.AreEqual(20, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
            }

        [Test]
        public void TestCtorWithAllParams()
        // Arrange & Acts
            {
            // Arrange & Acts
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            //Assert
            Assert.AreEqual(30, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
            }

        [Test]
        public void TestCtorWithInitialComparer()
            {
            // Arrange & Acts
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            //Assert
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
            }

        [Test]
        public void TestAddIncreaseSize()
            {
            // Act
            this.names.Add("Nasko");

            //Assert
            Assert.AreEqual(1, this.names.Size);
            }

        [Test]
        public void TestAddNullThrowsException()
            {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
            }


        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
            {
            string[] namesCollection = new string[] { "Balkan", "Georgi", "Rosen" };
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase)
                {
                    "Rosen",
                    "Georgi",
                    "Balkan"
                };

            Assert.That(namesCollection, Is.EqualTo(this.names));
            }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
            {
            for (int i = 0; i < 17; i++)
                {
                this.names.Add("Gosho");
                }

            Assert.IsTrue(this.names.Size == 17);
            Assert.IsTrue(this.names.Capacity != 16);
            }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
            {
            ICollection<string> items = new List<string>()
                {
                    "Gosho",
                    "Pesho"
                };

            this.names.AddAll(items);

            Assert.IsTrue(this.names.Size == 2);
            }

        [Test]
        public void TestAddingAllFromNullThrowsException()
            {
            ICollection<string> items = new List<string>()
                {
                    "Gosho",
                    null
                };

            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(items));
            }

        [Test]
        public void TestAddAllKeepsSorted()
            {
            string[] sortedNamesCollection = new string[]
            {
                    "Asen",
                    "Katya"
            };

            ICollection<string> inputItems = new List<string>()
                {
                    "Katya",
                    "Asen"
                };

            this.names.AddAll(inputItems);

            Assert.AreEqual(sortedNamesCollection, this.names);
            }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
            {
            this.names.Add("Ivan");

            this.names.Remove("Ivan");

            Assert.IsTrue(this.names.Size == 0);
            }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
            {
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            this.names.Remove("Ivan");

            Assert.IsTrue(!this.names.Any(x => x == "Ivan"));
            }

        [Test]
        public void TestRemovingNullThrowsException()
            {
            this.names.Add("Gosho");

            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
            }

        [Test]
        public void TestJoinWithNull()
            {
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
            }

        [Test]
        public void TestJoinWorksFine()
            {
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            Assert.AreEqual("Ivan, Nasko", this.names.JoinWith(", "));
            }
        }
    }
