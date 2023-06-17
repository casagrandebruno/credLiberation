# Bem vindo à API CredLiberation

Esse é um projeto simplificado para processamento de Liberação de Crédito sem uso de banco de dados, mas com base em código e escalabilidade para tal, caso necessário.

# Regras

## Tipos de Crédito

Para a finalidade deste teste existem 5 tipos de crédito:
- Crédito Direto -> Taxa de 2%
- Crédito Consignado -> Taxa de 1%
- Crédito Pessoa Jurídica -> Taxa de 5%
- Crédito Pessoa Física -> Taxa de 3%
- Crédito Imobiliário -> Taxa de 9%

## Variáveis de Entrada

Os campos a serem enviados por meio de JSON serão:
- Valor do Crédito
- Tipo de Crédito
- Quantidade de Parcelas
- Data do Primeiro Vencimento
- Validações das Entradas

## Validações de Entrada

Qualquer tipo de pedido de crédito necessitará de aprovação em determinadas validações. Como essas validações podem ser flutuantes, no código foi definido que seria possível alterá-las no envio do JSON com o intuito de tornar a API escalável.
As validações possuem os seguintes campos:

- Valor Máximo
- Quantidade Mínima de Parcelas
- Quantidade Máxima de Parcelas
- Valor Mínimo, a depender do Tipo de Crédito
- Mínimo de dias para a Data do Primeiro Vencimento à partir da data atual
- Máximo de dias para a Data do Primeiro Vencimento à partir da data atual

## Resultado

Qualquer pedido de crédito retornará um mesmo padrão de resultado, definido previamente, com os seguintes campos:

- Status do Crédito -> Aprovado ou Recusado, de acordo com as validações
- Valor total com Juros -> O incremento da porcentagem de juros no valor do crédito
- Valor dos Juros

## Considerações Finais

Esta API visa apenas realizar a validação de pedidos de crédito acerca dos padrões previamente definidos. Além disso, traz consigo documentação base do Swagger para tornar mais fácil a testagem e verificação, sem necessidade do uso de PostMan e similares.

