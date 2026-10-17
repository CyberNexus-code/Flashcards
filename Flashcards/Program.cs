using Flashcards.Extensions;
using Flashcards.Repositories;
using Flashcards.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddCustomServices();

using var host = builder.Build();

var repository = host.Services.GetRequiredService<FlashcardRepository>();

var mainMenu = host.Services.GetRequiredService<MainMenu>();


mainMenu.Show();
