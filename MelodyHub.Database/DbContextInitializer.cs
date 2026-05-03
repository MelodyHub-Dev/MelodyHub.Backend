using MelodyHub.Domain;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Database;

public class DbContextInitializer
{
    public static void Initialize(MelodyHubDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.InstrumentCategories.Any() || 
            context.Instruments.Any() || 
            context.Materials.Any() ||
            context.InstrumentMaterials.Any())
        {
            return;
        }

        SeedCategories(context);
        SeedMaterials(context);
        SeedInstruments(context);
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
}