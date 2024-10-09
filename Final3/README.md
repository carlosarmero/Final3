(english)Task description:

1.Cloning this repository will allow you to run the 3 tests in the UnitTest1.cs file (UC-1, UC-2, UC-3),
all 3 tests are successful in Firefox, but UC-2 tends to fail in Chrome.
Browser can be changed in the LoginTests constructor, line 11 in UnitTest1.cs file.

UC-1: -Write any credentials in the "Username" and "Password" fields.
-Then delete what you wrote in both fields and click on the "Login" button.
-Use fluent assertion to verify that the error message is the same as expected.

UC-2: -Write any credentials in the "Username" and "Password" fields.
-Then delete what you wrote in the password field and click on the "Login" button.
-Use fluent assertion to verify that the error message is the same as expected.

UC-3: -Valid credentials are entered in "Username" and "Password".
-Click on the "Login" button and use fluent assertion to verify that the title is the expected one: "Swag Labs”.

2. Each time an error occurs, it will be logged in the log-.txt file in the Logs folder.
3. Test is Parametrized using [InlineData("parameter1", "parameter2")].
4. You can switch to the parallel branch with git checkout to perform parallel execution.
5. To perform the task, I used the additional options:
-Test Automation tool: Selenium WebDriver;
-Browsers: 1) Firefox; 2) Chrome;
-Locators: XPath;
-Test Runner: xUnit;
-Assertions: Fluent Assertion;
-Loggers: SeriLog.
6. Into the PageObjects folder you can see the LoginPages.cs file, in which we locate the web elements using xpath.

(español)Task description:

1.Al clonar este repositorio se podran ejecutar las 3 pruebas del archivo UnitTest1.cs (UC-1, UC-2, UC-3), 
las 3 pruebas son exitosas en firefox, pero en chrome tiende a fallar la UC-2.
El navegador se puede cambiar en el constructor LoginTests, línea 11 del archivo UnitTest1.cs.

UC-1: -Se escriben las credenciales cualquiera en los campos "Nombre de usuario" y "Contraseña".
-Luego se borra lo escrito en ambos campos y se da click en boton "Login".
-Se usa fluent assertion para verificar que el mensaje de error sea igual al esperado.

UC-2: -Se escriben las credenciales cualquiera en los campos "Nombre de usuario" y "Contraseña".
-Luego se borra lo escrito en el campo de contraseña y se da click en boton "Login".
-Se usa fluent assertion para verificar que el mensaje de error sea igual al esperado.

UC-3: -Se escriben las credenciales validas en "Nombre de usuario" y "Contraseña".
-Se da click en boton "Login" y se usa fluent assertion para verificar que el titulo sea el esperado: "Swag Labs”.

2. Cada vez que se produzca un error, este se registrara en erchivo log-.txt de la carpeta Logs.
3. Se parametrizan las pruebas usando [InlineData("parametro1", "parametro2")].
4. Se puede cambiar a la rama parallel con git checkout para hacer ejecucion paralela.
5. Para realizar la tarea utilice las opciones adicionales:
-Test Automation tool: Selenium WebDriver;
-Browsers: 1) Firefox; 2) Chrome;
-Locators: XPath;
-Test Runner: xUnit;
-Assertions: Fluent Assertion;
-Loggers: SeriLog.
6. Dentro de la carpeta PageObjects podemos ver el archivo LoginPages.cs, en el cual ubicamos los elementos web mediante xpath.


