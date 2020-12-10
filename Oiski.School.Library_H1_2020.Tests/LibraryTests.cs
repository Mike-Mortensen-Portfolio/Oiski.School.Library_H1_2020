using Oiski.School.Library_H1_2020.Application.System;
using Oiski.School.Library_H1_2020.Application.Users;
using System;
using Xunit;

namespace Oiski.School.Library_H1_2020.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void CreateLoanee_Test ()
        {
            //  Arrange

            //  Act
            Library.GetLibrary.CreateLoanee("Fiddle", "MeFancy@Perv.com", out Loanee _testLoanee);

            //  Assert
            Assert.NotNull(_testLoanee);
        }

        [Fact]
        public void SaveState_Test ()
        {
            //  Arrange

            //  Act
            Library.GetLibrary.SaveState();

            //  Assert
        }

        [Fact]
        public void LoadState_Test ()
        {
            //  Arrange

            //  Act
            Library.GetLibrary.LoadState();

            //  Assert
        }
    }
}
