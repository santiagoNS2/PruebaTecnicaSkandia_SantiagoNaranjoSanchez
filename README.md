# Prueba Técnica - Santiago Naranjo Sánchez

Esta solución contiene tres proyectos separados organizados bajo una sola solución de Visual Studio.

## 📁 Estructura del proyecto

- **ACMEModeladoDatos**: Proyecto principal para análisis y modelado de datos utilizando Entity Framework Core, SQL Server y programación orientada a objetos.
- **Algoritmos**: Proyecto con ejercicios clásicos de algoritmos (ej: bingo, inversión de texto, números primos).
- **ConceptosBasicos**: Proyecto con ejercicios básicos de programación.

---

## 🧱 Requisitos

- Visual Studio 2022 o superior
- .NET 8
- SQL Server (o LocalDB)
- Entity Framework Core Tools

---

## 🚀 ¿Cómo ejecutar cada proyecto por separado?

### 1. Establecer un proyecto de inicio:

1. En el Explorador de soluciones, haz clic derecho sobre el proyecto que deseas ejecutar (ej: `ACMEModeladoDatos`).
2. Selecciona **"Establecer como proyecto de inicio"**.
3. Presiona `Ctrl + F5` o `F5` para ejecutarlo.

---

## ⚙️ ¿Cómo crear y migrar la base de datos?

> Estos pasos aplican solo para el proyecto **ACMEModeladoDatos**.

1. Abre la **Consola del Administrador de paquetes NuGet** (menú: Herramientas > Administrador de paquetes NuGet > Consola).
2. Selecciona como **proyecto predeterminado**: `ACMEModeladoDatos`

### 🔁 Si necesitas recrear la base desde cero:

```powershell o la   Consola del Administrador de paquetes:
Add-Migration Init
Update-Database
```

Esto creará la base de datos `ACMEDB` con todas las tablas definidas en el modelo.

---

## 📊 ¿Cómo ver el diagrama entidad-relación en SQL Server?

1. Abre **SQL Server Management Studio (SSMS)**
2. Conéctate a la instancia `(localdb)\MSSQLLocalDB` o `localhost`, según tu cadena de conexión
3. Expande la base de datos `ACMEDB`
4. Clic derecho en **Database Diagrams** > **New Database Diagram**
5. Agrega las tablas que quieras visualizar

   ![image](https://github.com/user-attachments/assets/52cc8988-823a-4f1f-96be-7adc00c8e5da)


✅ Verás las relaciones visuales entre entidades (claves primarias/foráneas).

---

## 🧪 ¿Cómo probar las consultas de ACMEModeladoDatos?

Al ejecutar `ACMEModeladoDatos`, verás un menú en consola con las 7 consultas de análisis:

1. Deuda total por franquicia
2. Cliente con mayor saldo en canje
3. Cliente con mayor retiro en periodo (ingresa fechas)
...

Escribe el número de la consulta que deseas ejecutar y presiona Enter.

Los datos de ejemplo se insertan automáticamente la primera vez gracias al método `SeedData.Inicializar()`.

---

## 💡 Recomendaciones finales

- Si ocurre un error de acceso a base de datos, asegúrate de tener permisos o usar `(localdb)\MSSQLLocalDB`
- Puedes revisar o modificar la cadena de conexión en `AppDbContext.cs`
- Verifica que la base `ACMEDB` esté visible desde SSMS después de correr `Update-Database`

---

Gracias! 🙌
