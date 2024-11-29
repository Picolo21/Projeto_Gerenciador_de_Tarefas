# Sistema de Gerenciamento de Tarefas - TaskFlow

## Descrição
Um sistema de gerenciamento de tarefas desenvolvido em .NET 6.0 com MongoDB, permitindo criação, visualização e gerenciamento de projetos e tarefas.

## Requisitos
- .NET 6.0 SDK
- Docker
- Docker Compose

## Configuração e Execução

### Usando Docker Compose

1. Clone o repositório
```bash
git clone https://github.com/Picolo21/Projeto_Gerenciador_de_Tarefas.git
cd src
```

2. Executar a aplicação
```bash
docker-compose up
```

3. A API estará disponível em http://localhost:5000

### Swagger
Acesse a documentação da API em http://localhost:5000/swagger

## Estrutura do Projeto
- src/: Código fonte
- src/tests/: Testes de unidade
- Dockerfile: Configuração de build do container
- docker-compose.yml: Orquestração de serviços

## Testes
Execute os testes de unidade:
bash
dotnet test


## Perguntas para o PO (Fase 2)
1. Como deseja tratar a priorização das tarefas além da classificação atual?
2. Existe necessidade de implementar filtros mais complexos para relatórios?
3. Qual o fluxo desejado para transferência de tarefas entre projetos?
4. Como lidar com tarefas recorrentes ou com periodicidade?

## Melhorias Futuras (Fase 3)
1. Implementar autenticação e autorização
2. Adicionar suporte a notificações
3. Criar dashboard de analytics
4. Implementar integração com ferramentas de comunicação
5. Adicionar suporte a etiquetas e categorias de tarefas
6. Implementar sincronização em tempo real