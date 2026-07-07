# 🧩 DesafioCrudAPI

API desenvolvida como desafio técnico para demonstrar habilidades em **.NET**, **Entity Framework**, **LINQ** e **Testes Unitários**.
---

## 🚀 Tecnologias utilizadas
- **.NET 8**
- **Entity Framework Core**
- **SQL Server**
- **xUnit** + **Moq** (para testes unitários)
- **Swagger** (para documentação da API)

---

##  Estrutura do projeto

DesafioCrudAPI/
├── Controllers/
├── Data/
├── Entidade/
├── Repository/
├── Service/
├── Test/
└── Program.cs

---

##  Funcionalidades
- CRUD completo de contatos:
  - Criar contato
  - Listar todos
  - Buscar por ID
  - Atualizar
  - Remover

---

## Testes Unitários
Os testes cobrem as principais regras de negócio:
- Validação de idade (não pode ser 0 ou menor de 18)
- Persistência correta de contatos válidos

Execute os testes com:
```bash
dotnet test
