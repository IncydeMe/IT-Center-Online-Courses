
using App_Repository;
using App_Repository.Interfaces;
using App_Repository.Repositories;
using App_Service;
using App_Service.Interfaces;
using App_Service.Services;
using ITCenterService;
using Payment.Service.VNPay.Interfaces;
using Payment.Service.VNPay.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOwnedCourseRepository, OwnedCourseRepository>();
builder.Services.AddScoped<IOwnedLessonRepository, OwnedLessonRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ILearnerAssignmentRepository, LearnerAssignmentRepository>();



builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOwnedCourseService, OwnedCourseService>();
builder.Services.AddScoped<IOwnedLessonService, OwnedLessonService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ILearnerAssignmentService, LearnerAssignmentService>();
builder.Services.AddScoped<IVNPayService, VNPayService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
