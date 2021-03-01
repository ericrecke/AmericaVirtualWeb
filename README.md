# AmericaVirtual
 Proyecto de AmericaVirtual con 3 proyectos internos, uno de DataModel, un WebService y la Web.
 
Las respuestas del challenge de Sql se encuentran en la carpeta de Configuración.

Se utilizó el sistema MVC para crear la web, estan subidos los 3 proyectos, y se publicaron en las carpetas de Publish la web y el WCF. pueden ser levantados por IIS o, los proyectos con el visual Studio.

Se debe modificar La ruta del Servicio que consume la web para traer la información, tambien los datos de la conexión a la base de datos.
(En Web.config, en la Web y en el WS)
Que hay que modificar: (el data source, la ruta del sql(catalog), el id y el password)

  <connectionStrings>
    <add name="Default" connectionString="data source=localhost;initial catalog=DBNAME;user id=USER;password=PASSWORD;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
  </connectionStrings>
  (aqui corregir la ruta del Ws al puerto e ip que utilizen)
    <client>
      <endpoint address="http://localhost:24227/AmericaVirtualService.svc" binding="basicHttpBinding" bindingConfiguration="BasicHttpBinding_IAmericaVirtualService" contract="AmericaeReference.IAmericaVirtualService" name="BasicHttpBinding_IAmericaVirtualService" />
    </client>

Para poder consultar el clima segun el sector se debe estar Logueado. (Hay 2 tipos de Usuarios, (1) Usuario, (2)Admin).

Si estas logueado como Administrador te permitira visualizar 1 apartado aparte con Cruds
![Clip1895](https://user-images.githubusercontent.com/55958235/109458229-29ed2a80-7a3b-11eb-885f-ca0365e808db.png)

Los Users con tipoUser (Usuario), solamente podran visualizar el Inicio y ver su perfil(modificar su mail o nombre).

Herramientas que se utilizaron:
C#, MVC.net FW 4.6.2, Bootstrap, JavaScript, Jquery, Linq, WebService, NewtonSoftJson.

