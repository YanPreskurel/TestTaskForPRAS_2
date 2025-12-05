using NewsPortal.Models;

namespace NewsPortal.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Cases.Any())
            {
                // ---------------------------
                // Теги
                // ---------------------------
                var tags = new List<Tag>
                {
                    new Tag
                    {
                        Color = "#D5A968",
                        Translations = new List<TagTranslation>
                        {
                            new TagTranslation { Language = "ru", Name = "Dublin Transfer" }
                        }
                    },
                    new Tag
                    {
                        Color = "#1E6F89",
                        Translations = new List<TagTranslation>
                        {
                            new TagTranslation { Language = "ru", Name = "Effective access to procedures" }
                        }
                    },
                    new Tag
                    {
                        Color = "#B8B399",
                        Translations = new List<TagTranslation>
                        {
                            new TagTranslation { Language = "ru", Name = "Effective remedy" }
                        }
                    },
                    new Tag
                    {
                        Color = "#86D6B9",
                        Translations = new List<TagTranslation>
                        {
                            new TagTranslation { Language = "ru", Name = "Effective access to procedures" }
                        }
                    },
                    new Tag
                    {
                        Color = "#B4D4EB",
                        Translations = new List<TagTranslation>
                        {
                            new TagTranslation { Language = "ru", Name = "Inhuman or degrading treatment or punishment" }
                        }
                    },
                    new Tag
                    {
                        Color = "#000000",
                        Translations = new List<TagTranslation>
                        {
                            new TagTranslation { Language = "ru", Name = "Request to take back" }
                        }
                    }
                };
                context.Tags.AddRange(tags);

                // ---------------------------
                // Адвокаты
                // ---------------------------
                var lawyers = new List<Lawyer>
                {
                    new Lawyer
                    {
                        Translations = new List<LawyerTranslation>
                        {
                            new LawyerTranslation
                            {
                                Language = "ru",
                                Name = "ДРОЗДОВ Вадим",
                                Position = "Адвокат",
                                PhotoImagePath = "pictures/person-1.jpg"
                            }
                        }
                    },
                    new Lawyer
                    {
                        Translations = new List<LawyerTranslation>
                        {
                            new LawyerTranslation
                            {
                                Language = "ru",
                                Name = "МАТЮЩЕНКОВ Никита",
                                Position = "Адвокат",
                                PhotoImagePath = "pictures/person-2.jpg"
                            }
                        }
                    }
                };
                context.Lawyers.AddRange(lawyers);

                // ---------------------------
                // Документы по делу
                // ---------------------------
                var documents = new List<CaseDocument>
                {
                    new CaseDocument
                    {
                        Translations = new List<CaseDocumentTranslation>
                        {
                            new CaseDocumentTranslation
                            {
                                Language = "ru",
                                Title = "Решение судебного дела",
                                FilePath = "#",
                                Type = "PDF"
                            }
                        }
                    },
                    new CaseDocument
                    {
                        Translations = new List<CaseDocumentTranslation>
                        {
                            new CaseDocumentTranslation
                            {
                                Language = "ru",
                                Title = "Свидетельство о предоставлении статуса беженца",
                                FilePath = "#",
                                Type = "PDF"
                            }
                        }
                    }
                };
                context.CaseDocuments.AddRange(documents);

                // ---------------------------
                // CallToActionBlock
                // ---------------------------
                var callToAction = new CallToActionBlock
                {
                    Translations = new List<CallToActionBlockTranslation>
                    {
                        new CallToActionBlockTranslation
                        {
                            Language = "ru",
                            Title = "У вас есть вопрос?",
                            Text = "Наша компания осуществляет поддержку и профессиональную юридическую консультацию имигрантам за границей",
                            ButtonText = "Получить консультацию"
                        }
                    }
                };
                context.CallToActionBlocks.Add(callToAction);

                // ---------------------------
                // Кейсы
                // ---------------------------
                var case1 = new Case
                {
                    FlagImagePath = "images/flags/England.png",
                    StatusColor = "#B8B399",
                    Translations = new List<CaseTranslation>
                    {
                        new CaseTranslation
                        {
                            Language = "ru",
                            Title = "К.К. против Швейцарии",
                            Country = "Швейцария",
                            Organization = "Комитет ООН по правам ребенка",
                            ShortDescription = "Идентификацию личности иностранца, ходатайствующегоо защите, не имеющего документа для выезда за границу либо предъявившего подложный или поддельный документ ...",
                            Status = "завершено успешно",
                            CaseFullDescription = new CaseFullDescription
                            {
                                MessageNumber = "Сообщение № 110/2020",
                                StatusText = "Депортация в Грузию остановлена",
                                CaseType = "отказ в убежище и депортация в страну происхождения / проживания",
                                Paragraph1 = "On Tuesday 7 June 2016, the CJEU delivered its judgments in Ghezelbash and Karim. These cases relate to the scope of the right to an effective remedy in recital 19 and Article 27(1) of the Dublin III Regulation.",
                                Section1Title = "C-63/15 Ghezelbash",
                                Section1Text = "Mr Ghezelbash, an Iranian national, had his asylum claim in the Netherlands rejected following the acceptance of a ‘take back’ request by France pursuant to Article 12(4) DRIII. After being informed of this, the applicant submitted circumstantial evidence in support of his claims that he had returned to Iran from France for over three months, and argued that the Netherlands was responsible for his application, as this was where he had lodged his first asylum claim. The Rechtbank den Haag requested a ruling from the CJEU on whether the applicant had the right to an effective legal remedy to appeal against the application of the Chapter III criteria used to determine the responsible Member State (MS).",
                                Quote = "The Court dismissed the argument that enabling an appeal against the misapplication of Chapter.",
                                Paragraph2 = "The Court thus concluded that Article 27(1) of the Dublin III Regulation should be interpreted as meaning that an asylum seeker is entitled to plead, in an appeal against a decision to transfer him, the incorrect application of one of the criteria for determining responsibility laid down in Chapter III of the Dublin III Regulation.",
                                Note1 = "Процедура предоставления, утраты, лишения статуса беженца регулируется Законом «О предоставлении иностранным гражданам и лицам без гражданства статуса беженца, дополнительной и временной защиты», а также Постановлением Совета Министров «Вопросы предоставления иностранным».",
                                Section2Title = "C-155/15 Karim",
                                Section2Text = "Mr Karim is a Syrian national who had his asylum claim in Sweden rejected after Slovenia accepted a ‘take back’ request pursuant to Article 13 of the Dublin III Regulation. Slovenia confirmed its willingness to process the asylum claim after being informed of additional information which indicated that Mr Karim had left the territory of the Member States for over three months, in circumstances covered by Article 19(2) of the Dublin III Regulation. The applicant appealed against the transfer decision, and the Stockholm Administrative Court of Appeal requested a preliminary ruling on the 1st of April 2015.",
                                ListTitle = "Work in the case of K. K. V. Switzerland:",
                                ListItems = "gathering information about the policy of assistance to refugees;\npreparation of documents in the case;\ndefense of the defendant in court and representation of his interests.",
                                Paragraph3 = "The Court acknowledged the fact that after the submissions of new documents indicating that Mr. Karim had left the territory for over three months, a new procedure for determining the responsible Member State had started. The Court then referred to paragraphs 30-61 of the Ghezelbash judgment and reiterated that Article 27(1), read in the light of recital 19, provides an asylum seeker with an effective remedy against a transfer decision made in respect of him, which may concern the examination of the application of that Regulation. Again, the Court’s decision is in line with Advocate General Sharpston’s opinion. It is noteworthy to highlight that the Court clarifies that the right to an effective remedy is not limited to systemic deficiencies in the asylum procedure or reception conditions which provide grounds for believing that the applicant would face a real risk of being subjected to inhuman or degrading treatment within the meaning of Article 4 of the Charter, thereby moving away from its interpretation in Abdullahi concerning the Dublin II Regulation.",
                                Note2 = "Процедура предоставления, утраты, лишения статуса беженца регулируется Законом «О предоставлении иностранным гражданам и лицам без гражданства статуса беженца, дополнительной и временной защиты», а также Постановлением Совета Министров «Вопросы предоставления иностранным».",
                                Note3 = "Процедура предоставления, утраты, лишения статуса беженца регулируется Законом «О предоставлении иностранным гражданам».",
                                DecisionTitle = "Решение",
                                DecisionText = "Депортация остановлена на время рассмотрения дела в Комитете",
                                DecisionLink = "https://www.."
                            }
                        }                      
                    }
                };
                context.Cases.Add(case1);

                var case2 = new Case
                {
                    FlagImagePath = "images/flags/England.png",
                    StatusColor = "#B8B399",
                    Translations = new List<CaseTranslation>
                    {
                        new CaseTranslation
                        {
                            Language = "ru",
                            Title = "Дискриминация",
                            Country = "Германия",
                            Organization = "Орган жалобы",
                            ShortDescription = "Идентификацию личности иностранца, ходатайствующегоо защите, не имеющего документа для выезда за границу.",
                            Status = "завершено успешно",
                            CaseFullDescription = new CaseFullDescription
                            {
                                MessageNumber = "Сообщение № 110/2020",
                                StatusText = "Депортация в Грузию остановлена",
                                CaseType = "отказ в убежище и депортация в страну происхождения / проживания",
                                Paragraph1 = "On Tuesday 7 June 2016, the CJEU delivered its judgments in Ghezelbash and Karim. These cases relate to the scope of the right to an effective remedy in recital 19 and Article 27(1) of the Dublin III Regulation.",
                                Section1Title = "C-63/15 Ghezelbash",
                                Section1Text = "Mr Ghezelbash, an Iranian national, had his asylum claim in the Netherlands rejected following the acceptance of a ‘take back’ request by France pursuant to Article 12(4) DRIII. After being informed of this, the applicant submitted circumstantial evidence in support of his claims that he had returned to Iran from France for over three months, and argued that the Netherlands was responsible for his application, as this was where he had lodged his first asylum claim. The Rechtbank den Haag requested a ruling from the CJEU on whether the applicant had the right to an effective legal remedy to appeal against the application of the Chapter III criteria used to determine the responsible Member State (MS).",
                                Quote = "The Court dismissed the argument that enabling an appeal against the misapplication of Chapter.",
                                Paragraph2 = "The Court thus concluded that Article 27(1) of the Dublin III Regulation should be interpreted as meaning that an asylum seeker is entitled to plead, in an appeal against a decision to transfer him, the incorrect application of one of the criteria for determining responsibility laid down in Chapter III of the Dublin III Regulation.",
                                Note1 = "Процедура предоставления, утраты, лишения статуса беженца регулируется Законом «О предоставлении иностранным гражданам и лицам без гражданства статуса беженца, дополнительной и временной защиты», а также Постановлением Совета Министров «Вопросы предоставления иностранным».",
                                Section2Title = "C-155/15 Karim",
                                Section2Text = "Mr Karim is a Syrian national who had his asylum claim in Sweden rejected after Slovenia accepted a ‘take back’ request pursuant to Article 13 of the Dublin III Regulation. Slovenia confirmed its willingness to process the asylum claim after being informed of additional information which indicated that Mr Karim had left the territory of the Member States for over three months, in circumstances covered by Article 19(2) of the Dublin III Regulation. The applicant appealed against the transfer decision, and the Stockholm Administrative Court of Appeal requested a preliminary ruling on the 1st of April 2015.",
                                ListTitle = "Work in the case of K. K. V. Switzerland:",
                                ListItems = "gathering information about the policy of assistance to refugees;\npreparation of documents in the case;\ndefense of the defendant in court and representation of his interests.",
                                Paragraph3 = "The Court acknowledged the fact that after the submissions of new documents indicating that Mr. Karim had left the territory for over three months, a new procedure for determining the responsible Member State had started. The Court then referred to paragraphs 30-61 of the Ghezelbash judgment and reiterated that Article 27(1), read in the light of recital 19, provides an asylum seeker with an effective remedy against a transfer decision made in respect of him, which may concern the examination of the application of that Regulation. Again, the Court’s decision is in line with Advocate General Sharpston’s opinion. It is noteworthy to highlight that the Court clarifies that the right to an effective remedy is not limited to systemic deficiencies in the asylum procedure or reception conditions which provide grounds for believing that the applicant would face a real risk of being subjected to inhuman or degrading treatment within the meaning of Article 4 of the Charter, thereby moving away from its interpretation in Abdullahi concerning the Dublin II Regulation.",
                                Note2 = "Процедура предоставления, утраты, лишения статуса беженца регулируется Законом «О предоставлении иностранным гражданам и лицам без гражданства статуса беженца, дополнительной и временной защиты», а также Постановлением Совета Министров «Вопросы предоставления иностранным».",
                                Note3 = "Процедура предоставления, утраты, лишения статуса беженца регулируется Законом «О предоставлении иностранным гражданам».",
                                DecisionTitle = "Решение",
                                DecisionText = "Депортация остановлена на время рассмотрения дела в Комитете",
                                DecisionLink = "https://www.."
                            }
                        }
                    }
                };

                context.Cases.Add(case2);

                // ---------------------------
                // Страница "Кто мы"
                // ---------------------------
                var whoWeAre = new WhoWeArePage
                {
                    Translations = new List<WhoWeArePageTranslation>
                    {
                        new WhoWeArePageTranslation
                        {
                            Language = "ru",
                            Title = "кто мы",
                            Description1 = "Адвокатское бюро \"VD\" осуществляет свою деятельность в Швейцарии и ЕС, объединяет сплоченную команду практикующих адвокатов в сфере гражданского права.",
                            Description2 = "Адвокаты \"VD\" успешно сопровождают проекты различной степени сложности, оказывают юридическую помощь владельцам, руководителям бизнеса и гражданам, нуждающимся в защите и восстановлении нарушенных прав.",
                            SectionTitle = "Мы сохраняем конфидиальность каждого клиента",
                            SectionText1 = "Мы сохраняем строгую конфидициальность каждого клиента. Наша деятельность полностью соответствует GDPR, законами конфидиальности.",
                            SectionText2 = "GDPR усиливает существующие и вводит новые права гражданам ЕС, а также дает гражданам больше контроля над своими личными данными. Кроме того GDPR предоставляет простые и рабочие инструменты гражданам ЕС для реализации своих прав, упрощая механизмы обращения в надзорные органы, например, жалобы в электронном виде."
                        }
                    }
                };
                context.WhoWeArePages.Add(whoWeAre);

                // ---------------------------
                // Пояснения (CaseNotes)
                // ---------------------------
                var notes = new List<CaseNote>
                {
                    new CaseNote
                    {
                        Translations = new List<CaseNoteTranslation>
                        {
                            new CaseNoteTranslation
                            {
                                Language = "ru",
                                Title = "Пояснение",
                                Text = "Процедура предоставления, утраты, лишения статуса беженца регулируется Законом «О предоставлении иностранным гражданам и лицам без гражданства статуса беженца...»."
                            }
                        }
                    },

                    new CaseNote
                    {
                        Translations = new List<CaseNoteTranslation>
                        {
                            new CaseNoteTranslation
                            {
                                Language = "ru",
                                Title = "Пояснение",
                                Text = "Краткое пояснение о процедуре обращения в уполномоченные органы согласно действующему законодательству."
                            }
                        }
                    }
                };

                context.CaseNotes.AddRange(notes);

                context.SaveChanges();
            }
        }
    }
}
