#language: pt-br
Funcionalidade: Login
	Login na aplicacao

@mytag
Cenario: Logar na aplicação
	Dado que o usuário acessa a url
	Quando clicar no link de login
	E preencher campos obrigatórios com admin e password
	E clicar no botão de log in
	Entao o link de Employee Details é exibido

Cenario: Logar na aplicação com dados errados
	Dado que o usuário acessa a url
	Quando clicar no link de login
	E preencher campos obrigatórios com <usuario> e <senha>
	E clicar no botão de log in
	Entao a mensagem de erro <mensagem> é exibida

	Exemplos:
		| usuario | senha    | mensagem               |
		| admim   | password | Invalid login attempt. |
		| admin   | pasword  | Invalid login attempt. |
		| admim   | pasword  | Invalid login attempt. |