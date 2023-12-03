using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));

var constr = builder.Configuration.GetConnectionString("App1");
builder.Services.AddSqlServer<App1Context>(constr);

builder.Services.AddTransient<IOrderRepo, OrderRepo>();
builder.Services.AddTransient<ISpecialOrderRepo, SpecialOrderRepo>();
builder.Services.AddTransient<ILocalOrderRepo, LocalOrderRepo>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ISpecialOrderService, SpecialOrderService>();
builder.Services.AddTransient<ILocalOrderService, LocalOrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapOrderApi();
app.MapSpecialOrderApi();
app.MapLocalOrderApi();

app.Run();

/*
select * from orders
select * from orderitems order by orderid
select * from SpecialItemDatas
*/