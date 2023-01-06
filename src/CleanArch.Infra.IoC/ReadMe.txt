- Na implementação da Injeção de dependência na ASP.NET Core, temos o conceito de lifetimes ou "tempo de
vidas" que especifica quando um objeto injetado é criado ou recriado.

- Transient (AddTransient) — Cria os objetos a cada vez que forem solicitados
- Scoped (AddScoped) — Cria os objetos uma vez por solicitação
- Singleton (AddSingleton) — Cria os objetos apenas na primeira vez que for solicitado