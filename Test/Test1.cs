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

            // Ruta de tu ejecutable
            string appPath = @"D:\Documentos Segundo SSD\Proyectos Visual Studio 2022\Sistema\Sistema-de-Gestion-de-Alquiler-y-Reservaciones\Gestion de Alquiler y Reservaciones\bin\Debug\Gestion de Alquiler y Reservaciones.exe";

            appiumOptions.AddAdditionalCapability("app", appPath);
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl), appiumOptions);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestMethod]
        public void PruebasIniciales_PruebaAcceso()
        {
            //LOGIN
            accesoAlLogin();

            // ⏱️ Espera a que la ventana principal cargue por completo
            esperar(1500);

            // 🔴 AGREGAR ESTO: Cambiar el foco a la última ventana abierta/activa
            cambiarFoco();

            //MODULO CLIENTES
            nuevoCliente(); //Nuevo Cliente
        }

        private void accesoAlLogin()
        {
            //=============================================================
            //LOGIN PRINCIPAL
            //=============================================================
            var txtUsuario = _driver.FindElementByAccessibilityId("txtUsuario");
            var txtPassword = _driver.FindElementByAccessibilityId("txtContra");
            var btnIngresar = _driver.FindElementByAccessibilityId("btnIngresar");

            // INTENTO 1: Datos vacios
            esperar(5000);
            txtUsuario.Clear();
            txtPassword.Clear();
            btnIngresar.Click();

            CerrarAlertaSiExiste(); //Cerrar el mensaje de error

            // INTENTO 2: Credenciales Incorrectas 2
            esperar(5000);
            txtUsuario.Clear();
            txtUsuario.SendKeys("SergiO");
            txtPassword.Clear();
            txtPassword.SendKeys("SERGIO");
            btnIngresar.Click();

            CerrarAlertaSiExiste(); //Cerrar el mensaje de error

            // INTENTO 3: Credenciales Correctas
            esperar(7000);
            txtUsuario.Clear();
            txtUsuario.SendKeys("sergio");
            txtPassword.Clear();
            txtPassword.SendKeys("sergio");
            btnIngresar.Click();
        }

        private void nuevoCliente()
        {
            var btnClientes = _driver.FindElementByAccessibilityId("btnClientes");
            btnClientes.Click();

            var txtNombreCliente = _driver.FindElementByAccessibilityId("txtNombre");
            txtNombreCliente.Clear();
            txtNombreCliente.SendKeys("Sergio");
            esperar(9000);
            txtNombreCliente.SendKeys(" Rolando Inestroza Amaya");
            esperar(1000);


            var txtIdentidad = _driver.FindElementByAccessibilityId("txtIdentidad");
            txtIdentidad.Clear();
            txtIdentidad.SendKeys("050");
            esperar(10000);
            txtIdentidad.SendKeys("42000");
            esperar(2000);
            txtIdentidad.SendKeys("00119");
            esperar(1000);

            var txtTelefono = _driver.FindElementByAccessibilityId("txtTelefono");
            txtTelefono.Clear();
            txtTelefono.SendKeys("9999");
            esperar(9000);
            txtTelefono.SendKeys("9999");

            var txtCorreo = _driver.FindElementByAccessibilityId("txtCorreo");
            txtCorreo.Clear();
            txtCorreo.SendKeys("sergioinestroza");
            esperar(9000);
            txtCorreo.SendKeys("@unah.com");
            esperar(2000);
        }

        private void

        // Método auxiliar para descartar mensajes de confirmación sin que falle el test si no aparecen
        private void CerrarAlertaSiExiste()
        {
            try
            {
                esperar(1500);

                _driver.FindElementByName("Aceptar").Click();
            }
            catch (Exception)
            {
                // Si no hay ventana flotante, ignora y sigue adelante
            }
        }

        private void esperar(int delay)
        {
            System.Threading.Thread.Sleep(delay);
        }

        private void cambiarFoco()
        {
            // 🔴 AGREGAR ESTO: Cambiar el foco a la última ventana abierta/activa
            var allHandles = _driver.WindowHandles;
            if (allHandles.Count > 0)
            {
                _driver.SwitchTo().Window(allHandles[0]); // O allHandles[allHandles.Count - 1]
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_driver != null)
            {
                //_driver.Quit();
                _driver = null;
            }
        }
    }
}