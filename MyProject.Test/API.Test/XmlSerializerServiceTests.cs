/*using Moq;
using MyProject.Api;
using MyProject.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Test.API.Test
{
    public class XmlSerializerServiceTests
    {
        [Theory]
        [InlineData("<UserData><Email>async@gmail.com</Email><Password>Admin@123</Password><ConfirmPassword>Admin@123</ConfirmPassword><UserName>Async</UserName><IsActive>true</IsActive><PhoneNumber>771122333</PhoneNumber><UserGroupId>1</UserGroupId></UserData>")]
        // Add more InlineData for other test scenarios
        public void Deserialize_WithValidXml_ShouldReturnDeserializedObject(string xml)
        {
            // Arrange
            var mockSerializer = new Mock<IXmlSerializerService>();
            var service = new XmlSerializerService();

            // Act
            var result = service.Deserialize<CreateUserRequestDTO>(xml);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on expected behavior after deserialization
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        // Add more InlineData for other test scenarios like empty or null xml
        public void Deserialize_WithNullOrEmptyXml_ShouldThrowException(string xml)
        {
            // Arrange
            var service = new XmlSerializerService();

            // Act & Assert
            Assert.Throws<Exception>(() => service.Deserialize<CreateUserRequestDTO>(xml));
        }
    }
}
*/