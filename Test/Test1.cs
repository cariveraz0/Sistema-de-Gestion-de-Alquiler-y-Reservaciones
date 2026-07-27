using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

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

            // 🔴 AGREGAR ESTO: Cambiar el foco a la última ventana abierta/activa
            cambiarFoco();

            //MODULO MANTENIMIENTO
            nuevoMantenimiento(); //Nuevo mantenimiento
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
            esperar(1000);
            btnIngresar.Click();

            CerrarAlertaSiExiste(); //Cerrar el mensaje de error

            // INTENTO 2: Credenciales Incorrectas 2
            esperar(5000);
            txtUsuario.Clear();
            txtUsuario.SendKeys("SergiO");
            txtPassword.Clear();
            txtPassword.SendKeys("SERGIO");
            esperar(1000);
            btnIngresar.Click();

            CerrarAlertaSiExiste(); //Cerrar el mensaje de error

            // INTENTO 3: Credenciales Correctas
            esperar(7000);
            txtUsuario.Clear();
            txtUsuario.SendKeys("sergio");
            txtPassword.Clear();
            txtPassword.SendKeys("sergio");
            esperar(1000);
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
            txtIdentidad.SendKeys("0501");
            esperar(10000);
            txtIdentidad.SendKeys("2000");
            esperar(2000);
            txtIdentidad.SendKeys("00119");
            esperar(1000);

            var txtTelefono = _driver.FindElementByAccessibilityId("txtTelefono");
            txtTelefono.Clear();
            txtTelefono.SendKeys("9482");
            esperar(9000);
            txtTelefono.SendKeys("5566");

            var txtCorreo = _driver.FindElementByAccessibilityId("txtCorreo");
            txtCorreo.Clear();
            txtCorreo.SendKeys("amayasergio31");
            esperar(9000);
            txtCorreo.SendKeys("@gmail.com");
            esperar(2000);

            var btnGuardar = _driver.FindElementByAccessibilityId("btnGuardar");
            btnGuardar.Click();
            esperar(1000);

            cambiarFoco();

            var btnSi = _driver.FindElementByName("Sí");
            btnSi.Click();
            esperar(1000);

            cambiarFoco();

            var btnAceptar = _driver.FindElementByName("Aceptar");
            btnAceptar.Click();
            esperar(1000);

            cambiarFoco();
        }

        private void nuevoMantenimiento()
        {
            var btnMantenimiento = _driver.FindElementByAccessibilityId("btnMantenimiento");
            btnMantenimiento.Click();
            cambiarFoco();
            esperar(1000);

            var cboPropiedad = _driver.FindElementByAccessibilityId("cboPropiedad");
            cboPropiedad.Click();
            // Método B: Si prefieres navegar con las flechas
            cboPropiedad.SendKeys(OpenQA.Selenium.Keys.Down); // Baja a la primera opción
            cboPropiedad.SendKeys(OpenQA.Selenium.Keys.Enter); // Confirma la selección
            esperar(1000);

            var cboTecnico = _driver.FindElementByAccessibilityId("cboTecnico");
            cboTecnico.Click();
            cboTecnico.SendKeys(OpenQA.Selenium.Keys.Down);
            cboTecnico.SendKeys(OpenQA.Selenium.Keys.Down);
            cboTecnico.SendKeys(OpenQA.Selenium.Keys.Enter);
            esperar(1000);

            var cboTipo = _driver.FindElementByAccessibilityId("cboTipo");
            cboTipo.Click();
            cboTipo.SendKeys(OpenQA.Selenium.Keys.Down);
            cboTipo.SendKeys(OpenQA.Selenium.Keys.Enter);
            esperar(1000);

            var txtDescripcion = _driver.FindElementByAccessibilityId("txtDescripcion");
            txtDescripcion.SendKeys("Esto solo es una prueba de los Analistas.");
            esperar(1000);

            //Para dtpProgramada
            var dtpProgramada = _driver.FindElementByAccessibilityId("dtpProgramada");

            // 1. Dar clic para enfocar el control
            dtpProgramada.Click();

            // 2. Limpiar o seleccionar el contenido existente enviando combinación de teclas (opcional pero seguro)
            // Envía la fecha deseada respetando el formato de tu sistema (ej. 21072026 para 21/07/2026)
            dtpProgramada.SendKeys("10");

            // 3. Confirmar con Enter o Tab para mover el foco fuera
            dtpProgramada.SendKeys(OpenQA.Selenium.Keys.Enter);
            esperar(1000);

            //Para realizar una ultima validacion antes del error con el cbotipo
            cboTipo.Click();
            cboTipo.SendKeys(OpenQA.Selenium.Keys.Up);
            cboTipo.SendKeys(OpenQA.Selenium.Keys.Enter);
            esperar(1000);

            //Regresarlo como estaba
            cboTipo.Click();
            cboTipo.SendKeys(OpenQA.Selenium.Keys.Down);
            cboTipo.SendKeys(OpenQA.Selenium.Keys.Enter);
            esperar(1000);

            var btnGuardar = _driver.FindElementByAccessibilityId("btnGuardar");
            btnGuardar.Click();
            esperar(2000);
            CerrarAlertaSiExiste();
        }

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