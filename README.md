# DesafioFULL
App desenvolvido com: 
 * ASP.NET Core, C# (Visual Studio 2019) e EntityFramework
 * Angular e TypeScript
 * Bootstrap
 * MySQL Community Server (Utilizado metodologia Code First)

## Instruções de instalação
1. Clone o repositório.
2. Abra o arquivo de solução (DesafioFULL.sln) e compile .
3. Instale o banco de dado mysql server caso não o tenha.
4. Pelo console selecione o projeto <u>DesafioFULL.Repositorio</u> ou (caminho do projeto pelo cmd) e rode o comando update-datase.
5. No arquivo `config.json` localizado no projeto <u>DesafioFULL.Web</u> encontra-se a string de conexão com o banco de dados.
````json
  "ConnectionStrings": {
    "MySqlConnection": "Persist Security Info=False;server=localhost;database=DesafioFull;uid=root;password=root;AllowUserVariables=True;port=3306"
  }
````