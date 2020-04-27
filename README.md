# AppOpenWeather
Xamarin Forms 

<img src="https://github.com/lucasboliveira/AppOpenWeather/blob/master/src/app1.PNG"><img src="https://github.com/lucasboliveira/AppOpenWeather/blob/master/src/app3.PNG">
<img src="https://github.com/lucasboliveira/AppOpenWeather/blob/master/src/app2.PNG">

## Arquitetura
O padrão MVVM visa como principal objetivo estabelecer uma clara separação de responsabilidades das camadas de interação com o usuário das camadas de regras de negócio.

- View - Tem a responsabilidade de definir a aparência ou estrutura que o usuário vê na tela utilizando a linguagem XAML.

- Model - Encapsula a lógica de negócios e os dados. O Modelo nada mais é do que o Modelo de domínio de uma aplicação.

- ViewModel - Tem a resposonsavilidade de disponibilizar para a View uma lógica de apresentação implementando propriedades e comandos. 

- Services - Interfaces e implementações dos servicos de navegação e do repositório.

- Helpers - Camada de acesso a dados.

## Bibliotecas de Terceiros:

- **Nome do pacote: Newtonsoft.Json**
- Autor: James Newton-King
- Id: Newtonsoft.Json
- Versão: 12.0.3
- Url: https://www.nuget.org/packages/Newtonsoft.Json/

Realiza o parsing do JSON "citiy.list.json" e da API "api.openweathermap.org".

- **Nome do pacote: SQLite-net-PCL**
- Autor: Frank A. Krueger
- Id: sqlite-net-pcl
- Versão: 1.6.292
- Url: nuget.org/packages/sqlite-net-pcl

É um ORM básico que permite que você armazene e recupere com facilidade objetos no banco de dados SQLite local em um dispositivo. 

## Melhorias

- Não foi testando no iOS por não possuir um ambiente.
- Criar projeto de teste unitário.
- Criar Services separado o acesso as API.
- Centralizar em um appsettings.json todas variaveis de ambiente como: nome banco de dados URL da API.
