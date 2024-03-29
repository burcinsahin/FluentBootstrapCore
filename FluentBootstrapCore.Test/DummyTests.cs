﻿using System.IO.Compression;
using System.Reflection;

namespace FluentBootstrapCore.Test
{
    [TestClass]
    public class DummyTests
    {
        public TestContext? TestContext { get; set; }

        [TestMethod]
        public void GetHashCode_Should()
        {
            var person1 = new Person("Mahmut", "Tamburi");
            var person2 = new Person("Mahmut", "Tamburi");
            var person3 = new PersonA("Mahmut", "Tamburacı");
            TestContext?.WriteLine(person1.GetHashCode().ToString());
            TestContext?.WriteLine(person2.GetHashCode().ToString());
            TestContext?.WriteLine(person1.ToString());
            TestContext?.WriteLine(person2.ToString());
            TestContext?.WriteLine(person3.ToString());

            person1.Should().NotBeSameAs(person2);
            person1.GetHashCode().Should().Be(person2.GetHashCode());
            person1.Should().BeEquivalentTo(person2);
        }

        [TestMethod]
        public void ZipFile_Should()
        {
            var dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var slnDir = dirInfo.GetFirstParentMatches("FluentBootstrapCore");
            var cssDir = slnDir.GetDirectories("CssFiles", SearchOption.AllDirectories).Single();
            var zipFileInfo = cssDir.GetFiles("bootstrap-icons-1.10.3.zip").Single();

            TestContext?.WriteLine(zipFileInfo.FullName);

            using var zip = ZipFile.OpenRead(zipFileInfo.FullName);
            foreach (var entry in zip.Entries)
            {
                TestContext?.WriteLine(entry.Name);
            }
        }


        private class PersonA : Person
        {
            public int ID { get; set; }

            internal PersonA(string name, string surname) : base(name, surname)
            {
            }
        }

        private class Person
        {
            public string Name { get; private set; }
            public string Surname { get; private set; }
            public byte Age { get; set; }

            internal Person(string name, string surname)
            {
                Name = name;
                Surname = surname;
            }

            #region Overrides
            public override string ToString()
            {
                var result = "";

                var props = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in props)
                {
                    result += $"{prop.Name}:{prop.GetValue(this)}; ";
                }
                return result;
            }

            public override bool Equals(object? obj)
            {
                if (obj == null) return false;
                if (obj is Person p)
                    return p.Name == Name && p.Surname == Surname;
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Surname, Age);
            }
            #endregion
        }
    }


    public static class StringExtensions
    {
        public static string Double(this string val)
        {
            return val + val;
        }

        public static DirectoryInfo GetFirstParentMatches(this DirectoryInfo directoryInfo, string name)
        {
            while (directoryInfo.Parent != null)
            {
                directoryInfo = directoryInfo.Parent;
                if (directoryInfo.Name == name)
                    return directoryInfo;
            }
            throw new DirectoryNotFoundException();
        }
    }
}