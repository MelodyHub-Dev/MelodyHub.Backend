using MelodyHub.Domain;
using MelodyHub.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace MelodyHub.Database;

public class DbContextInitializer
{
    public static void Initialize(MelodyHubDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.InstrumentCategories.Any() ||
            context.Instruments.Any() ||
            context.Materials.Any() ||
            context.InstrumentMaterials.Any() ||
            context.BlogArticles.Any() ||
            context.Quizzes.Any())
        {
            return;
        }

        SeedCategories(context);
        SeedMaterials(context);
        SeedInstruments(context);
        SeedBlogArticles(context);
        SeedQuizzes(context);
    }

    private static void SeedCategories(MelodyHubDbContext context)
    {
        var categories = new List<InstrumentCategory>
        {
            new InstrumentCategory
            {
                Id = Guid.NewGuid(),
                Name = "Струнные",
                Slug = "string-instruments",
                Description = "Инструменты с струнным звучанием"
            },
            new InstrumentCategory
            {
                Id = Guid.NewGuid(),
                Name = "Духовые",
                Slug = "wind-instruments",
                Description = "Духовые музыкальные инструменты"
            },
            new InstrumentCategory
            {
                Id = Guid.NewGuid(),
                Name = "Ударные",
                Slug = "percussion",
                Description = "Ударные музыкальные инструменты"
            },
            new InstrumentCategory
            {
                Id = Guid.NewGuid(),
                Name = "Электронные",
                Slug = "electronic",
                Description = "Электронные музыкальные инструменты"
            }
        };

        context.InstrumentCategories.AddRange(categories);
        context.SaveChanges();
    }

    private static void SeedMaterials(MelodyHubDbContext context)
    {
        var materials = new List<Material>
        {
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Кленовая древесина",
                Description = "Качественная кленовая древесина для корпуса",
                Unit = MaterialUnit.Kg,
                AvgPrice = 450.00m,
                Category = "Древесина"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Еловая древесина",
                Description = "Еловая древесина для верхней деки",
                Unit = MaterialUnit.Kg,
                AvgPrice = 380.00m,
                Category = "Древесина"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Струны (набор)",
                Description = "Набор струн для гитары",
                Unit = MaterialUnit.Piece,
                AvgPrice = 250.00m,
                Category = "Струны"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Лак для дерева",
                Description = "Матовый лак для финишной обработки",
                Unit = MaterialUnit.Liter,
                AvgPrice = 600.00m,
                Category = "Химия"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Латунь",
                Description = "Латунные детали для фурнитуры",
                Unit = MaterialUnit.Kg,
                AvgPrice = 550.00m,
                Category = "Металл"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Корпусная фурнитура",
                Description = "Комплект корпусной фурнитуры",
                Unit = MaterialUnit.Piece,
                AvgPrice = 1200.00m,
                Category = "Фурнитура"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Лакировочная краска",
                Description = "Краска для покраски корпуса",
                Unit = MaterialUnit.Liter,
                AvgPrice = 800.00m,
                Category = "Краски"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Питание (блок)",
                Description = "Блок питания для электрогитары",
                Unit = MaterialUnit.Piece,
                AvgPrice = 350.00m,
                Category = "Электроника"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Кабель 3.5мм",
                Description = "Аудиокабель для подключения",
                Unit = MaterialUnit.Meter,
                AvgPrice = 45.00m,
                Category = "Электроника"
            },
            new Material
            {
                Id = Guid.NewGuid(),
                Name = "Пластик ABS",
                Description = "Пластик для корпуса",
                Unit = MaterialUnit.Kg,
                AvgPrice = 280.00m,
                Category = "Пластик"
            }
        };

        context.Materials.AddRange(materials);
        context.SaveChanges();
    }

    private static void SeedInstruments(MelodyHubDbContext context)
    {
        var categories = context.InstrumentCategories.ToList();
        var materials = context.Materials.ToList();

        var instruments = new List<Instrument>
        {
            new Instrument
            {
                Id = Guid.NewGuid(),
                Name = "Классическая гитара",
                Description = "Классическая гитара с деревянным корпусом и стальными струнами. Идеальный выбор для начинающих и опытных музыкантов. Обладает теплым и насыщенным звучанием.",
                ShortDescription = "Классическая гитара с деревянным корпусом",
                CategoryId = categories[0].Id,
                Difficulty = DifficultyLevel.Beginner,
                EstimatedHours = 40,
                MainImageUrl = "",
                ViewsCount = 1250,
                CreatedAt = DateTime.Now.AddDays(-30)
            },
            new Instrument
            {
                Id = Guid.NewGuid(),
                Name = "Электрогитара",
                Description = "Электрогитара с двойным бриджем и humbucker- Pickup. Подходит для рока, металла и других энергичных жанров. Требует усилителя.",
                ShortDescription = "Электрогитара для рок-музыкантов",
                CategoryId = categories[0].Id,
                Difficulty = DifficultyLevel.Intermediate,
                EstimatedHours = 50,
                MainImageUrl = "",
                ViewsCount = 980,
                CreatedAt = DateTime.Now.AddDays(-25)
            },
            new Instrument
            {
                Id = Guid.NewGuid(),
                Name = "Укулеле",
                Description = "Маленький гавайский инструмент с 4 струнами. Легко освоить и брать с собой в путешествия. Имеет яркий и веселый звук.",
                ShortDescription = "Маленький гавайский инструмент",
                CategoryId = categories[0].Id,
                Difficulty = DifficultyLevel.Beginner,
                EstimatedHours = 25,
                MainImageUrl = "",
                ViewsCount = 850,
                CreatedAt = DateTime.Now.AddDays(-20)
            },
            new Instrument
            {
                Id = Guid.NewGuid(),
                Name = "Флейта",
                Description = "Металлическая флейта с клапанной системой. Имеет чистое и прозрачное звучание. Подходит для классической и народной музыки.",
                ShortDescription = "Металлическая флейта",
                CategoryId = categories[1].Id,
                Difficulty = DifficultyLevel.Intermediate,
                EstimatedHours = 35,
                MainImageUrl = "",
                ViewsCount = 720,
                CreatedAt = DateTime.Now.AddDays(-15)
            },
            new Instrument
            {
                Id = Guid.NewGuid(),
                Name = "Саксофон",
                Description = "Медный саксофон с басовой трубой. Имеет богатое и выразительное звучание. Требует регулярного ухода за лаком.",
                ShortDescription = "Медный саксофон",
                CategoryId = categories[1].Id,
                Difficulty = DifficultyLevel.Expert,
                EstimatedHours = 60,
                MainImageUrl = "",
                ViewsCount = 640,
                CreatedAt = DateTime.Now.AddDays(-10)
            },
            new Instrument
            {
                Id = Guid.NewGuid(),
                Name = "Барабанная установка",
                Description = "Полноразмерная барабанная установка с креплениями и педалями. Включает в себя все необходимое для игры в группе.",
                ShortDescription = "Полноразмерная барабанная установка",
                CategoryId = categories[2].Id,
                Difficulty = DifficultyLevel.Intermediate,
                EstimatedHours = 45,
                MainImageUrl = "",
                ViewsCount = 1100,
                CreatedAt = DateTime.Now.AddDays(-35)
            },
            new Instrument
            {
                Id = Guid.NewGuid(),
                Name = "Синтезатор",
                Description = "61-клавишный синтезатор с множеством звуков и эффектов. Идеален для создания электронной музыки и экспериментов со звуком.",
                ShortDescription = "61-клавишный синтезатор",
                CategoryId = categories[3].Id,
                Difficulty = DifficultyLevel.Intermediate,
                EstimatedHours = 30,
                MainImageUrl = "",
                ViewsCount = 890,
                CreatedAt = DateTime.Now.AddDays(-18)
            },
            new Instrument
            {
                Id = Guid.NewGuid(),
                Name = "Электронный бас",
                Description = "4-струнный электрический бас-гитара с активной электроникой. Имеет мощный низкий диапазон и удобный гриф.",
                ShortDescription = "4-струнный электрический бас",
                CategoryId = categories[3].Id,
                Difficulty = DifficultyLevel.Beginner,
                EstimatedHours = 35,
                MainImageUrl = "",
                ViewsCount = 760,
                CreatedAt = DateTime.Now.AddDays(-12)
            }
        };

        context.Instruments.AddRange(instruments);
        context.SaveChanges();

        SeedBlueprints(context, instruments);

        // Связывание инструментов с материалами
        var instrumentMaterials = new List<InstrumentMaterial>();

        // Классическая гитара
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[0].Id,
            MaterialId = materials[0].Id,
            Quantity = 2.5m,
            Notes = "Корпус и гриф"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[0].Id,
            MaterialId = materials[1].Id,
            Quantity = 1.2m,
            Notes = "Верхняя дека"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[0].Id,
            MaterialId = materials[2].Id,
            Quantity = 1m,
            Notes = "Набор струн"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[0].Id,
            MaterialId = materials[3].Id,
            Quantity = 0.3m,
            Notes = "Лакировка"
        });

        // Электрогитара
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[1].Id,
            MaterialId = materials[0].Id,
            Quantity = 2.0m,
            Notes = "Корпус"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[1].Id,
            MaterialId = materials[4].Id,
            Quantity = 0.5m,
            Notes = "Фурнитура"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[1].Id,
            MaterialId = materials[5].Id,
            Quantity = 1m,
            Notes = "Комплект фурнитуры"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[1].Id,
            MaterialId = materials[7].Id,
            Quantity = 1m,
            Notes = "Блок питания"
        });

        // Укулеле
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[2].Id,
            MaterialId = materials[1].Id,
            Quantity = 0.8m,
            Notes = "Корпус"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[2].Id,
            MaterialId = materials[2].Id,
            Quantity = 1m,
            Notes = "Струны"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[2].Id,
            MaterialId = materials[3].Id,
            Quantity = 0.2m,
            Notes = "Лакировка"
        });

        // Флейта
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[3].Id,
            MaterialId = materials[4].Id,
            Quantity = 1.5m,
            Notes = "Труба и клапаны"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[3].Id,
            MaterialId = materials[3].Id,
            Quantity = 0.1m,
            Notes = "Смазка для клапанов"
        });

        // Саксофон
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[4].Id,
            MaterialId = materials[4].Id,
            Quantity = 3.0m,
            Notes = "Корпус и труба"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[4].Id,
            MaterialId = materials[3].Id,
            Quantity = 0.2m,
            Notes = "Лакировка"
        });

        // Барабанная установка
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[5].Id,
            MaterialId = materials[8].Id,
            Quantity = 50m,
            Notes = "Кабели"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[5].Id,
            MaterialId = materials[4].Id,
            Quantity = 2.0m,
            Notes = "Крепления"
        });

        // Синтезатор
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[6].Id,
            MaterialId = materials[9].Id,
            Quantity = 1.5m,
            Notes = "Корпус"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[6].Id,
            MaterialId = materials[8].Id,
            Quantity = 10m,
            Notes = "Кабели"
        });

        // Электронный бас
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[7].Id,
            MaterialId = materials[0].Id,
            Quantity = 1.8m,
            Notes = "Корпус"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[7].Id,
            MaterialId = materials[2].Id,
            Quantity = 1m,
            Notes = "Струны"
        });
        instrumentMaterials.Add(new InstrumentMaterial
        {
            InstrumentId = instruments[7].Id,
            MaterialId = materials[8].Id,
            Quantity = 5m,
            Notes = "Кабель"
        });

        context.InstrumentMaterials.AddRange(instrumentMaterials);
        context.SaveChanges();
    }

    private static void SeedBlueprints(MelodyHubDbContext context, List<Instrument> instruments)
    {
        var blueprints = new List<Blueprint>();

        // Классическая гитара - 5 шагов
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[0].Id,
            StepNumber = 1,
            Title = "Подготовка древесины",
            Content = "Выберите качественную кленовую и еловую древесину. Древесина должна быть высушенна до влажности 8-10%.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[0].Id,
            StepNumber = 2,
            Title = "Формирование корпуса",
            Content = "Вырежьте детали корпуса по шаблону. Соберите верхнюю и нижнюю деки.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 180
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[0].Id,
            StepNumber = 3,
            Title = "Установка грифа",
            Content = "Прикрепите гриф к корпусу. Убедитесь в правильной установке и выравнивании.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 90
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[0].Id,
            StepNumber = 4,
            Title = "Установка струн",
            Content = "Натяните струны и настройте инструмент. Проверьте высоту струн над ладами.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[0].Id,
            StepNumber = 5,
            Title = "Финишная обработка",
            Content = "Покройте инструмент лаком и дайте высохнуть. Проверьте все соединения.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });

        // Электрогитара - 6 шагов
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[1].Id,
            StepNumber = 1,
            Title = "Подготовка корпуса",
            Content = "Изготовьте корпус из кленовой древесины. Установите крепления для фурнитуры.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 150
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[1].Id,
            StepNumber = 2,
            Title = "Установка звукоснимателей",
            Content = "Установите humbucker-загрузчики. Подключите проводку согласно схеме.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 90
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[1].Id,
            StepNumber = 3,
            Title = "Установка бриджа",
            Content = "Установите двойной бридж. Настройте натяжение струн.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[1].Id,
            StepNumber = 4,
            Title = "Электроника",
            Content = "Установите блок питания и аудиокабели. Проверьте соединения.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 45
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[1].Id,
            StepNumber = 5,
            Title = "Лакировка",
            Content = "Покройте корпус лакировочной краской. Дайте высохнуть.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[1].Id,
            StepNumber = 6,
            Title = "Финальная сборка",
            Content = "Установите фурнитуру и струны. Настройте инструмент.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });

        // Укулеле - 4 шага
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[2].Id,
            StepNumber = 1,
            Title = "Формирование корпуса",
            Content = "Соберите корпус из еловой древесины. Установите боковые стенки.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[2].Id,
            StepNumber = 2,
            Title = "Установка грифа",
            Content = "Прикрепите гриф к корпусу. Установите лады.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 90
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[2].Id,
            StepNumber = 3,
            Title = "Установка струн",
            Content = "Натяните струны. Настройте инструмент на стандартную гавайскую настройку.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 45
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[2].Id,
            StepNumber = 4,
            Title = "Финишная обработка",
            Content = "Покройте лаком. Проверьте все соединения.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });

        // Флейта - 5 шагов
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[3].Id,
            StepNumber = 1,
            Title = "Изготовление трубы",
            Content = "Изготовьте металлическую трубу с нужными отверстиями. Обработайте поверхность.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 180
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[3].Id,
            StepNumber = 2,
            Title = "Установка клапанов",
            Content = "Установите клапанную систему. Смажьте лаком для герметичности.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[3].Id,
            StepNumber = 3,
            Title = "Настройка отверстий",
            Content = "Проделайте отверстия для пальцев. Проверьте звучание.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 90
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[3].Id,
            StepNumber = 4,
            Title = "Сборка",
            Content = "Соберите все части флейты. Проверьте герметичность.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[3].Id,
            StepNumber = 5,
            Title = "Финальная проверка",
            Content = "Проверьте звучание и настройте инструмент.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 45
        });

        // Саксофон - 7 шагов
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[4].Id,
            StepNumber = 1,
            Title = "Изготовление корпуса",
            Content = "Изготовьте медную трубу с конической формой. Обработайте поверхность.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 240
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[4].Id,
            StepNumber = 2,
            Title = "Установка клапанов",
            Content = "Установите систему клапанов. Проверьте герметичность.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 180
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[4].Id,
            StepNumber = 3,
            Title = "Установка резиновых колпачков",
            Content = "Установите резиновые колпачки на клапаны для герметичности.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[4].Id,
            StepNumber = 4,
            Title = "Сборка труб",
            Content = "Соберите все части трубы. Проверьте соединения.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 90
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[4].Id,
            StepNumber = 5,
            Title = "Лакировка",
            Content = "Покройте лаком для защиты от коррозии.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[4].Id,
            StepNumber = 6,
            Title = "Установка дыхательной мембраны",
            Content = "Установите дыхательную мембрану. Проверьте герметичность.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[4].Id,
            StepNumber = 7,
            Title = "Финальная настройка",
            Content = "Настройте инструмент и проверьте звучание.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });

        // Барабанная установка - 6 шагов
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[5].Id,
            StepNumber = 1,
            Title = "Подготовка корпусов",
            Content = "Изготовьте корпуса б��рабанов. Обработайте поверхность.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 180
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[5].Id,
            StepNumber = 2,
            Title = "Установка мембран",
            Content = "Установите верхние и нижние мембраны на барабаны.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[5].Id,
            StepNumber = 3,
            Title = "Установка креплений",
            Content = "Установите крепления для тарелок и барабанов.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 90
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[5].Id,
            StepNumber = 4,
            Title = "Установка педалей",
            Content = "Установите педали для бас-барабана.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[5].Id,
            StepNumber = 5,
            Title = "Подключение кабелей",
            Content = "Подключите аудиокабели для микрофонов.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 45
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[5].Id,
            StepNumber = 6,
            Title = "Настройка",
            Content = "Настройте натяжение мембран и проверьте звучание.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });

        // Синтезатор - 4 шага
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[6].Id,
            StepNumber = 1,
            Title = "Изготовление корпуса",
            Content = "Изготовьте корпус из ABS пластика. Установите панель управления.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[6].Id,
            StepNumber = 2,
            Title = "Установка клавиш",
            Content = "Установите 61 клавишу. Проверьте работу механизмов.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 90
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[6].Id,
            StepNumber = 3,
            Title = "Электроника",
            Content = "Установите звуковой процессор и блок питания.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 120
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[6].Id,
            StepNumber = 4,
            Title = "Финальная сборка",
            Content = "Установите кабели и проверьте все функции.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });

        // Электронный бас - 5 шагов
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[7].Id,
            StepNumber = 1,
            Title = "Подготовка корпуса",
            Content = "Изготовьте корпус из кленовой древесины. Установите фурнитуру.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 150
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[7].Id,
            StepNumber = 2,
            Title = "Установка грифа",
            Content = "Установите гриф с 4 струнами. Настройте натяжение.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 90
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[7].Id,
            StepNumber = 3,
            Title = "Электроника",
            Content = "Установите активную электронику и кабели.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 60
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[7].Id,
            StepNumber = 4,
            Title = "Установка струн",
            Content = "Установите 4 струны. Настройте инструмент.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 45
        });
        blueprints.Add(new Blueprint
        {
            Id = Guid.NewGuid(),
            InstrumentId = instruments[7].Id,
            StepNumber = 5,
            Title = "Финальная проверка",
            Content = "Проверьте звучание и настройте инструмент.",
            ImageUrl = "",
            DrawingUrl = "",
            EstimatedTimeMinutes = 30
        });

        context.Blueprints.AddRange(blueprints);
        context.SaveChanges();
    }


    private static void SeedBlogArticles(MelodyHubDbContext context)
    {
        var user = new User
        {
            Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
            Email = "user@gmail.com",
            PasswordHash = "asd",
            Role = UserRole.User,
            IsVerifiedEmail = true
        };

        var admin = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@gmail.com",
            Role = UserRole.Admin,
            IsVerifiedEmail = true
        };

        var passwordHasher = new PasswordHasher<User>();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "admin123");

        context.Add(user);
        context.Add(admin);
        context.SaveChanges();

        var blogArticles = new List<BlogArticle>
        {
            new BlogArticle
            {
                Id = Guid.NewGuid(),
                Title = "Как выбрать первую гитару",
                Content = "В этой статье мы расскажем о всех критериях выбора первой гитары. От материала корпуса до размера грифа - мы разберем все, что важно для начинающего музыканта.",
                Excerpt = "Полное руководство по выбору первой гитары для начинающих. Что смотреть при покупке?",
                AuthorId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
                ImageUrl = "",
                ViewsCount = 1250,
                IsPublished = true,
                PublishedAt = DateTime.Now.AddDays(-30),
                CreatedAt = DateTime.Now.AddDays(-30)
            },
            new BlogArticle
            {
                Id = Guid.NewGuid(),
                Title = "Основы настройки инструментов",
                Content = "Настройка инструмента - это фундамент для любого музыканта. В этой статье мы разберем стандартные и альтернативные настройки для разных инструментов.",
                Excerpt = "Узнайте как правильно настраивать свои инструменты для идеального звучания.",
                AuthorId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
                ImageUrl = "",
                ViewsCount = 890,
                IsPublished = true,
                PublishedAt = DateTime.Now.AddDays(-20),
                CreatedAt = DateTime.Now.AddDays(-20)
            },
            new BlogArticle
            {
                Id = Guid.NewGuid(),
                Title = "Топ-5 материалов для начинающих",
                Content = "Какие материалы лучше всего подходят для первых проектов? Мы составили рейтинг самых доступных и качественных материалов для начинающих мастеров.",
                Excerpt = "Обзор лучших материалов для начинающих лутейщиков с ценами и характеристиками.",
                AuthorId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
                ImageUrl = "",
                ViewsCount = 650,
                IsPublished = true,
                PublishedAt = DateTime.Now.AddDays(-15),
                CreatedAt = DateTime.Now.AddDays(-15)
            },
            new BlogArticle
            {
                Id = Guid.NewGuid(),
                Title = "Секреты звука: лакировка",
                Content = "Лакировка - это не просто финишная обработка, это важный этап в создании звука инструмента. Рассказываем о типах лаков и их влиянии на звучание.",
                Excerpt = "Как лак влияет на звук инструмента и какой лак выбрать для разных пород дерева.",
                AuthorId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
                ImageUrl = "",
                ViewsCount = 420,
                IsPublished = true,
                PublishedAt = DateTime.Now.AddDays(-10),
                CreatedAt = DateTime.Now.AddDays(-10)
            },
            new BlogArticle
            {
                Id = Guid.NewGuid(),
                Title = "Частые ошибки новичков",
                Content = "Даже самые опытные музыканты начинали с ошибок. Мы собрали самые распространенные ошибки, которые совершают новички при создании инструментов.",
                Excerpt = "Как избежать типичных ошибок при первом изготовлении инструмента.",
                AuthorId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
                ImageUrl = "",
                ViewsCount = 1560,
                IsPublished = true,
                PublishedAt = DateTime.Now.AddDays(-5),
                CreatedAt = DateTime.Now.AddDays(-5)
            }
        };

        context.BlogArticles.AddRange(blogArticles);
        context.SaveChanges();
    }

    private static void SeedQuizzes(MelodyHubDbContext context)
    {
        var quizzes = new List<Quiz>
        {
            new Quiz
            {
                Id = Guid.NewGuid(),
                Title = "Основы акустики",
                Description = "Проверьте свои знания о физике звука и акустических инструментах",
                Difficulty = QuizDifficulty.Easy,
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-30)
            },
            new Quiz
            {
                Id = Guid.NewGuid(),
                Title = "Материалы для инструментов",
                Description = "Узнайте, какие материалы лучше всего подходят для разных типов инструментов",
                Difficulty = QuizDifficulty.Medium,
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-20)
            },
            new Quiz
            {
                Id = Guid.NewGuid(),
                Title = "История музыкальных инструментов",
                Description = "Погрузитесь в историю создания и развития музыкальных инструментов",
                Difficulty = QuizDifficulty.Hard,
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-10)
            }
        };

        context.Quizzes.AddRange(quizzes);
        context.SaveChanges();

        // Добавляем вопросы для первой викторины (Основы акустики)
        var quiz1 = quizzes[0];
        var questions1 = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz1.Id,
                QuestionText = "Что такое частота звука?",
                OptionA = "Громкость звука",
                OptionB = "Высота звука в герцах",
                OptionC = "Длительность звука",
                OptionD = "Тембр звука",
                CorrectAnswer = 'b',
                Explanation = "Частота измеряется в герцах (Гц) и определяет высоту звука. Чем выше частота, тем выше звук.",
                Points = 10
            },
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz1.Id,
                QuestionText = "Какой материал лучше всего резонирует для корпуса гитары?",
                OptionA = "Пластик",
                OptionB = "Клён",
                OptionC = "Сосна",
                OptionD = "Ель",
                CorrectAnswer = 'b',
                Explanation = "Клён обладает отличными акустическими свойствами и используется для изготовления корпусов многих инструментов.",
                Points = 10
            },
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz1.Id,
                QuestionText = "Что такое резонанс?",
                OptionA = "Отражение звука от поверхности",
                OptionB = "Усиление звука при совпадении частот",
                OptionC = "Искажение звука",
                OptionD = "Поглощение звука",
                CorrectAnswer = 'b',
                Explanation = "Резонанс - это явление, при котором амплитуда колебаний возрастает при совпадении собственной частоты системы с частотой внешнего воздействия.",
                Points = 10
            }
        };

        // Добавляем вопросы для второй викторины (Материалы)
        var quiz2 = quizzes[1];
        var questions2 = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz2.Id,
                QuestionText = "Какая древесина традиционно используется для верхней деки акустической гитары?",
                OptionA = "Клён",
                OptionB = "Ель",
                OptionC = "Дуб",
                OptionD = "Орех",
                CorrectAnswer = 'b',
                Explanation = "Ель обладает легкостью и отличными резонансными свойствами, что делает её идеальной для верхней деки.",
                Points = 10
            },
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz2.Id,
                QuestionText = "Какой материал используется для изготовления струн?",
                OptionA = "Нейлон",
                OptionB = "Сталь",
                OptionC = "Оба варианта верны",
                OptionD = "Ни один из вариантов",
                CorrectAnswer = 'c',
                Explanation = "Струны могут быть как нейлоновыми (для классических гитар), так и стальными (для акустических и электрогитар).",
                Points = 10
            },
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz2.Id,
                QuestionText = "Что такое палисандровое дерево?",
                OptionA = "Искусственный материал",
                OptionB = "Тропическая древесина",
                OptionC = "Металлический сплав",
                OptionD = "Пластик",
                CorrectAnswer = 'b',
                Explanation = "Палисандр - это тропическая древесина, часто используемая для грифов и декоративных элементов инструментов.",
                Points = 10
            }
        };

        // Добавляем вопросы для третьей викторины (История)
        var quiz3 = quizzes[2];
        var questions3 = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz3.Id,
                QuestionText = "В каком веке была изобретена скрипка?",
                OptionA = "XV век",
                OptionB = "XVI век",
                OptionC = "XVII век",
                OptionD = "XIV век",
                CorrectAnswer = 'b',
                Explanation = "Современная скрипка в её классическом виде была создана в Италии в XVI веке мастерами Андреа Амати и его семьёй.",
                Points = 10
            },
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz3.Id,
                QuestionText = "Кто считается отцом современной гитары?",
                OptionA = "Антонио Страдивари",
                OptionB = "Адольфо Санс",
                OptionC = "Лютер Берлин",
                OptionD = "Орландо Смит",
                CorrectAnswer = 'b',
                Explanation = "Адольфо Санс испанский гитарист и мастер, который считается отцом современной классической гитары.",
                Points = 10
            },
            new QuizQuestion
            {
                Id = Guid.NewGuid(),
                QuizId = quiz3.Id,
                QuestionText = "Какой инструмент является предком фортепиано?",
                OptionA = "Клавесин",
                OptionB = "Орган",
                OptionC = "Челеста",
                OptionD = "Спинет",
                CorrectAnswer = 'a',
                Explanation = "Клавесин был одним из основных предшественников фортепиано, изобретённым в XV веке.",
                Points = 10
            }
        };

        context.QuizQuestions.AddRange(questions1);
        context.QuizQuestions.AddRange(questions2);
        context.QuizQuestions.AddRange(questions3);
        context.SaveChanges();
    }
}