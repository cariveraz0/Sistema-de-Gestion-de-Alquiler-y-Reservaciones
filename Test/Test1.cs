using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace Test
{
    [TestClass]
    public class Test1
    {
        private WindowsDriver<WindowsElement> _driver;
        private const string WinAppDriverUrl = "http://127.0.0.1:4723";

        [TestInitialize]
        public void TestInitialize()
        {
            var appiumOptions = new AppiumOptions();

            // Sustituye por la ruta exactísima donde está tu .exe
            string appPath = @"""D:\Documentos Segundo SSD\Proyectos Visual Studio 2022\Sistema\Sistema-de-Gestion-de-Alquiler-y-Reservaciones\Gestion de Alquiler y Reservaciones\bin\Debug\Gestion de Alquiler y Reservaciones.exe""";

            appiumOptions.AddAdditionalCapability("app", appPath);
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl), appiumOptions);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestMethod]
        public void PruebasIniciales_PruebaAcceso()
        {
            // ==========================================
            // INVENTO 1: Credenciales Incorrectas 1
            // ==========================================
            var txtUsuario = _driver.FindElementByAccessibilityId("txtUsuario");
            var txtPassword = _driver.FindElementByAccessibilityId("txtContra");
            var btnIngresar = _driver.FindElementByAccessibilityId("btnIngresar");

            txtUsuario.Clear();
            txtUsuario.SendKeys("UsuarioInvalido1");
            txtPassword.Clear();
            txtPassword.SendKeys("claveErronea1");
            btnIngresar.Click();

            // Capturamos el MessageBox de error y le damos Aceptar
            var btnAceptarModal1 = _driver.FindElementByName("Aceptar");
            btnAceptarModal1.Click();


            // ==========================================
            // INTENTO 2: Credenciales Incorrectas 2
            // ==========================================
            txtUsuario.Clear();
            txtUsuario.SendKeys("UsuarioInvalido2");
            txtPassword.Clear();
            txtPassword.SendKeys("claveErronea2");
            btnIngresar.Click();

            // Volvemos a cerrar el MessageBox de error
            var btnAceptarModal2 = _driver.FindElementByName("Aceptar");
            btnAceptarModal2.Click();


            // ==========================================
            // INTENTO 3: Credenciales Correctas
            // ==========================================
            txtUsuario.Clear();
            txtUsuario.SendKeys("sergio");
            txtPassword.Clear();
            txtPassword.SendKeys("sergio"); // Pon tu contraseña real aquí
            btnIngresar.Click();

            // Aquí ya no sale el MessageBox de error y la app accede al sistema principal
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}