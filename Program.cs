using EasyCrudLocalPlayground.Entities;
using EasyCrudNET;

var easyCrud = new EasyCrud();

easyCrud.SetSqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyCrudTestDB;Trusted_Connection=True;MultipleActiveResultSets=true;");

var resFacturas = easyCrud
    .ExecuteRawQuery("select * from facturas")
    .MapResultTo<Factura>();

Console.WriteLine(resFacturas);

List <Cliente> clientes = new List<Cliente>();

var cl = new
{
    nombre = Faker.Name.First(),
    apellido = Faker.Name.Last(),
    empresa = Faker.Company.Name(),
    domicilio = Faker.Address.StreetName(),
    ciudad = Faker.Address.City(),
    codPostal = Faker.Address.UkPostCode().Substring(0, 3),
    telefono = Faker.Phone.Number().Substring(0, 5),
    estado = false
};

var rows = easyCrud
    .Insert()
    .Into("clientes")
    .Values("@nombre", "@apellido", "@empresa", "@domicilio", "@ciudad", "@codPostal", "@telefono", "@estado")
    .BindValues(cl)
    .SaveChanges();

Console.WriteLine(rows);

var cl2 = new
{
    nombre = Faker.Name.First(),
    apellido = Faker.Name.Last(),
    empresa = Faker.Company.Name(),
    domicilio = Faker.Address.StreetName(),
    ciudad = Faker.Address.City(),
    codPostal = Faker.Address.UkPostCode().Substring(0, 3),
    telefono = Faker.Phone.Number().Substring(0, 5),
    estado = false
};

var rows2 = easyCrud
    .BindValues(cl2)
    .SaveChangesRawQuery("insert into clientes values (@nombre, @apellido, @empresa, @domicilio, @ciudad, @codPostal, @telefono, @estado)");

Console.WriteLine(rows2);


var cl3 = new
{
    nombre = Faker.Name.First(),
    apellido = Faker.Name.Last(),
    empresa = Faker.Company.Name(),
    domicilio = Faker.Address.StreetName(),
    ciudad = Faker.Address.City(),
    codPostal = Faker.Address.UkPostCode().Substring(0, 3),
    telefono = Faker.Phone.Number().Substring(0, 5),
    estado = false
};

var rows3 = easyCrud.SaveChangesRawQuery($"insert into clientes values ('{cl3.nombre}', '{cl3.apellido}', '{cl3.empresa}', '{cl3.domicilio}', '{cl3.ciudad}', '{cl3.codPostal}', '{cl3.telefono}', '{cl3.estado}')");

Console.WriteLine(rows3);

var res = easyCrud.ExecuteRawQuery("select * from clientes").GetResult();

Console.WriteLine(res);

var res2 = easyCrud
    .Select("*")
    .From("clientes")
    .Where("nombre", "@nombre")
    .BindValues(new
    {
        nombre = cl3.nombre
    })
    .ExecuteQuery()
    .GetResult();

Console.WriteLine(res2);

var res3 = easyCrud
    .Select("*")
    .From("clientes")
    .Where("estado", "@estado")
    .And("codPostal", "@codigoPostal")
    .BindValues(new
    {
        estado = false,
        codigoPostal = cl2.codPostal
    })
    .ExecuteQuery()
    .MapResultTo<Cliente>();

Console.WriteLine(res3);

var res4 = easyCrud
    .Select("*")
    .From("clientes")
    .ExecuteQuery()
    .MapResultTo<Cliente>(res =>
    {
        var values = res.Select(o => o.FieldValue).ToList<object>();

        return new Cliente()
        {
            Id = int.Parse(values[0].ToString()),
            Nombre = values[1].ToString(),
            Apellido = values[2].ToString(),
        };
    });

Console.WriteLine(res4);

var res5 = easyCrud
    .Select("*")
    .From("facturas")
    .ExecuteQuery()
    .MapResultTo<Factura>();

Console.WriteLine(res5);

var success = easyCrud
    .BeginTransaction((queries) =>
    {
        queries.Add(("insert into facturas values (@clienteRef1, @fechaEmision1, @fechaVto1, @fechaPago1)", new
        {
            clienteRef1 = res4.First().Id,
            fechaEmision1 = DateTime.Now,
            fechaVto1 = DateTime.Now.AddDays(10),
            fechaPago1 = DateTime.Now.AddDays(5)
        }));
        
        queries.Add(("insert into facturas values (@clienteRef2, @fechaEmision2, @fechaVto2, @fechaPago2)", new
        {
            clienteRef2 = res4.ElementAt(1).Id,
            fechaEmision2 = DateTime.Now,
            fechaVto2 = DateTime.Now.AddDays(10),
            fechaPago2 = DateTime.Now.AddDays(5)
        }));
    
        queries.Add(("insert into facturas values ('1', GETDATE(), GETDATE(), GETDATE())", null));
    })
    .Commit();


Console.WriteLine(success);