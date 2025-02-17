create database salao_de_beleza;
use salao_de_beleza;

create table perfil (
    id_perf int primary key auto_increment,
    tipo_perf varchar(100) not null,
    agenda_perf varchar(100),
    comissoes_perf varchar(200),
    financeiro_perf varchar(200)
);
INSERT INTO perfil (
    tipo_perf, agenda_perf, comissoes_perf, financeiro_perf
) 
VALUES (
    'Administrador', 'Agenda Completa', 'Comissões de 5% sobre vendas', 'Controle de fluxo de caixa'
);

INSERT INTO perfil (tipo_perf, agenda_perf, comissoes_perf, financeiro_perf) 
VALUES 
('Administrador', 'Reuniões mensais', 'Comissões de vendas, bônus de performance', 'Controle de fluxo de caixa, planejamento financeiro');

INSERT INTO perfil (tipo_perf, agenda_perf, comissoes_perf, financeiro_perf) 
VALUES 
('Gerente', 'Reuniões semanais', 'Comissões de projetos concluídos', 'Análise de custos, orçamento de equipe');

INSERT INTO perfil (tipo_perf, agenda_perf, comissoes_perf, financeiro_perf) 
VALUES 
('Vendedor', 'Visitas diárias a clientes', 'Comissões sobre vendas realizadas', 'Controle de metas de vendas, relatórios de desempenho');



select * from perfil;

create table login (
    id_log int primary key auto_increment,
    email_log varchar(100) not null,
    senha_log varchar(100) not null
);
INSERT INTO login (email_log, senha_log)
VALUES
    ('usuario@exemplo.com', 'senha123'),
    ('admin@exemplo.com', 'admin123');

    INSERT INTO login (email_log, senha_log) 
VALUES 
('jose.silva@email.com', 'senha123');

INSERT INTO login (email_log, senha_log) 
VALUES 
('ana.martins@email.com', 'segura456');

INSERT INTO login (email_log, senha_log) 
VALUES 
('pedro.santos@email.com', 'pedro789');
    
    select * from login;


create table endereco (
    id_end int primary key auto_increment,
    rua_end varchar(45),
    bairro_end varchar(45),
    numero_end varchar(10),
    cidade_end varchar(45),
    estado_end varchar(45),
    pais_end varchar(45),
    cep_end varchar(8)
);

INSERT INTO endereco (rua_end, bairro_end, numero_end, cidade_end, estado_end, pais_end, cep_end) 
VALUES 
('Rua das Flores', 'Centro', '123', 'São Paulo', 'SP', 'Brasil', '01000000');

INSERT INTO endereco (rua_end, bairro_end, numero_end, cidade_end, estado_end, pais_end, cep_end) 
VALUES 
('Avenida Paulista', 'Bela Vista', '456', 'São Paulo', 'SP', 'Brasil', '01310000');

INSERT INTO endereco (rua_end, bairro_end, numero_end, cidade_end, estado_end, pais_end, cep_end) 
VALUES 
('Rua João Pessoa', 'Vila Progredior', '789', 'Campinas', 'SP', 'Brasil', '13010000');

    select * from endereco;


create table fornecedor (
    id_forn int primary key auto_increment,
    nome_forn varchar(300) not null,
    razao_social_forn varchar(100),
    cnpj_forn varchar(45) not null,
    tel_forn varchar(45),
    site_forn varchar(45),
    id_end_fk int,
    foreign key (id_end_fk) references endereco(id_end)
);
INSERT INTO fornecedor (nome_forn, razao_social_forn, cnpj_forn, tel_forn, site_forn, id_end_fk) 
VALUES 
('Fornecedor A', 'Razão Social A', '12.345.678/0001-90', '(11) 1234-5678', 'www.fornecedora.com.br', 1);

INSERT INTO fornecedor (nome_forn, razao_social_forn, cnpj_forn, tel_forn, site_forn, id_end_fk) 
VALUES 
('Fornecedor B', 'Razão Social B', '98.765.432/0001-01', '(21) 9876-5432', 'www.fornecedorb.com.br', 2);

INSERT INTO fornecedor (nome_forn, razao_social_forn, cnpj_forn, tel_forn, site_forn, id_end_fk) 
VALUES 
('Fornecedor C', 'Razão Social C', '12.345.678/0001-11', '(31) 1122-3344', 'www.fornecedorC.com.br', 3);

    select * from fornecedor;


create table cliente (
    id_cli int primary key auto_increment,
    nome_cli varchar(100) not null,
    email_cli varchar(100),
    tel_cli varchar(20),
    cpf_cli varchar(45) not null,
    sexo_cli varchar(45),
    data_nasc_cli date,
    id_end_fk int,
    foreign key (id_end_fk) references endereco(id_end)
);
INSERT INTO cliente (nome_cli, email_cli, tel_cli, cpf_cli, sexo_cli, data_nasc_cli, id_end_fk) 
VALUES 
('João Silva', 'joao.silva@email.com', '(11) 99876-5432', '123.456.789-00', 'Masculino', '1985-03-15', 1);

INSERT INTO cliente (nome_cli, email_cli, tel_cli, cpf_cli, sexo_cli, data_nasc_cli, id_end_fk) 
VALUES 
('Maria Oliveira', 'maria.oliveira@email.com', '(21) 98765-4321', '987.654.321-00', 'Feminino', '1990-07-20', 2);

INSERT INTO cliente (nome_cli, email_cli, tel_cli, cpf_cli, sexo_cli, data_nasc_cli, id_end_fk) 
VALUES 
('Carlos Santos', 'carlos.santos@email.com', '(31) 91234-5678', '123.789.456-00', 'Masculino', '1988-11-05', 3);

    select * from cliente;


create table caixa (
    id_caix int primary key auto_increment,
    usuario_caix varchar(100),
    data_inicio_caix date,
    valor_inicial_caix float,
    entrada_caix float,
    saida_caix float,
    saldo_final_caix float
);

INSERT INTO caixa (usuario_caix, data_inicio_caix, valor_inicial_caix, entrada_caix, saida_caix, saldo_final_caix) 
VALUES 
('João Silva', '2025-02-01', 1000.00, 500.00, 300.00, 1200.00);

INSERT INTO caixa (usuario_caix, data_inicio_caix, valor_inicial_caix, entrada_caix, saida_caix, saldo_final_caix) 
VALUES 
('Maria Oliveira', '2025-02-01', 1500.00, 800.00, 200.00, 2100.00);

INSERT INTO caixa (usuario_caix, data_inicio_caix, valor_inicial_caix, entrada_caix, saida_caix, saldo_final_caix) 
VALUES 
('Carlos Santos', '2025-02-01', 500.00, 300.00, 100.00, 700.00);

    select * from caixa;

create table categoria (
    id_cate int primary key auto_increment,
    nome_cate varchar(100),
    tipo_cate varchar(45),
    descricao_cate varchar(45)
);

INSERT INTO categoria (nome_cate, tipo_cate, descricao_cate) 
VALUES 
('Eletrônicos', 'Produtos', 'Produtos relacionados a eletrônicos');

INSERT INTO categoria (nome_cate, tipo_cate, descricao_cate) 
VALUES 
('Roupas', 'Vestuário', 'Vestuário feminino');

INSERT INTO categoria (nome_cate, tipo_cate, descricao_cate) 
VALUES 
('Alimentos', 'Comércio', 'Produtos alimentícios, incluindo');

    select * from categoria;

create table produto (
    id_prod int primary key auto_increment,
    nome_prod varchar(100),
    descricao_prod varchar(100),
    codigo_barras_prod varchar(45),
    categoria_prod varchar(100),
    valor_prod float,
    valor_custo_prod varchar(100),
    comissao_prod float,
    id_cate_fk int,
    foreign key (id_cate_fk) references categoria(id_cate)
);

INSERT INTO produto (nome_prod, descricao_prod, codigo_barras_prod, categoria_prod, valor_prod, valor_custo_prod, comissao_prod, id_cate_fk) 
VALUES 
('Smartphone XYZ', 'Celular de última geração', '1234567890123', 'Eletrônicos', 1500.00, '1000.00', 100.00, 1);

INSERT INTO produto (nome_prod, descricao_prod, codigo_barras_prod, categoria_prod, valor_prod, valor_custo_prod, comissao_prod, id_cate_fk) 
VALUES 
('Camiseta Polo', 'Camiseta masculina de algodão', '9876543210987', 'Roupas', 80.00, '50.00', 5.00, 2);

INSERT INTO produto (nome_prod, descricao_prod, codigo_barras_prod, categoria_prod, valor_prod, valor_custo_prod, comissao_prod, id_cate_fk) 
VALUES 
('Arroz Integral', 'Arroz integral de 5kg', '1234987654321', 'Alimentos', 20.00, '12.00', 2.00, 3);

    select * from produto;

create table estoque (
    id_est int primary key auto_increment,
    nomeprod_est varchar(100) not null,
    estoque_atual_est float,
    entrada_est float,
    preco_compra_est float,
    preco_venda_est float,
    id_forn_fk int,
    id_prod_fk int,
	foreign key (id_forn_fk) references fornecedor (id_forn),
    foreign key (id_prod_fk) references produto (id_prod)
);

INSERT INTO estoque (nomeprod_est, estoque_atual_est, entrada_est, preco_compra_est, preco_venda_est, id_forn_fk, id_prod_fk) 
VALUES 
('Smartphone XYZ', 100, 50, 1000.00, 1500.00, 1, 1);

INSERT INTO estoque (nomeprod_est, estoque_atual_est, entrada_est, preco_compra_est, preco_venda_est, id_forn_fk, id_prod_fk) 
VALUES 
('Camiseta Polo', 200, 100, 50.00, 80.00, 2, 2);

INSERT INTO estoque (nomeprod_est, estoque_atual_est, entrada_est, preco_compra_est, preco_venda_est, id_forn_fk, id_prod_fk) 
VALUES 
('Arroz Integral', 500, 200, 12.00, 20.00, 3, 3);

    select * from estoque;


create table baixa_uso_interno (
	id_baixa int primary key auto_increment,
    nome_baixa varchar(100),
    estoqueatual_baixa int,
    baixarestoque_baixa int,
    descricao_baixa varchar(100),
    id_est_fk int,
    foreign key (id_est_fk) references estoque (id_est)
    );

     INSERT INTO baixa_uso_interno (nome_baixa, estoqueatual_baixa, baixarestoque_baixa, descricao_baixa, id_est_fk) 
VALUES 
('Uso Interno Smartphone XYZ', 100, 10, 'Baixa para uso interno no escritório', 1);

INSERT INTO baixa_uso_interno (nome_baixa, estoqueatual_baixa, baixarestoque_baixa, descricao_baixa, id_est_fk) 
VALUES 
('Uso Interno Camiseta Polo', 200, 15, 'Baixa para uniformes dos funcionários', 2);

INSERT INTO baixa_uso_interno (nome_baixa, estoqueatual_baixa, baixarestoque_baixa, descricao_baixa, id_est_fk) 
VALUES 
('Uso Interno Arroz Integral', 500, 30, 'Baixa para refeitório interno', 3);
    
    select * from baixa_uso_interno;

create table pacote (
    id_pac int primary key auto_increment,
    nome_pacote_pac varchar(300) not null,
    valor_pacote_pac float not null,
    validade_pacote_pac date,
    itens_pacote_pac varchar(300)
);

    select * from pacote;
    
INSERT INTO pacote (nome_pacote_pac, valor_pacote_pac, validade_pacote_pac, itens_pacote_pac) 
VALUES 
('Pacote Básico', 99.90, '2025-12-31', 'Item A, Item B, Item C');

INSERT INTO pacote (nome_pacote_pac, valor_pacote_pac, validade_pacote_pac, itens_pacote_pac) 
VALUES 
('Pacote Intermediário', 199.90, '2026-06-30', 'Item D, Item E, Item F, Item G');

INSERT INTO pacote (nome_pacote_pac, valor_pacote_pac, validade_pacote_pac, itens_pacote_pac) 
VALUES 
('Pacote Premium', 299.90, '2026-12-31', 'Item H, Item I, Item J, Item K, Item L');

create table profissional (
    id_pro int primary key auto_increment,
    nome_pro varchar(100) not null,
	celular_pro varchar(100),
    email_pro varchar(100),
    cpf_pro varchar(45) not null,
    sexo_pro varchar(45),
    observacoes_pro varchar(45),
    expediente_pro varchar(300),
    possui_agenda_pro boolean,
    ativo_pro boolean,
    id_cate_fk int,
    id_log_fk int,
    id_perf_fk int,
    id_end_fk int,
    foreign key (id_cate_fk) references categoria(id_cate),
    foreign key ( id_log_fk) references login(id_log),
    foreign key (id_perf_fk) references perfil(id_perf),
    foreign key (id_end_fk) references endereco(id_end)
);

    select * from profissional;
    
    INSERT INTO profissional (nome_pro, celular_pro, email_pro, cpf_pro, sexo_pro, observacoes_pro, expediente_pro, possui_agenda_pro, ativo_pro, id_cate_fk, id_log_fk, id_perf_fk, id_end_fk) 
VALUES 
('Carlos Silva', '11987654321', 'carlos.silva@email.com', '123.456.789-00', 'Masculino', 'Especialista em fisioterapia', 'Seg-Sex: 08h - 18h', TRUE, TRUE, 1, 1, 2, 3);

INSERT INTO profissional (nome_pro, celular_pro, email_pro, cpf_pro, sexo_pro, observacoes_pro, expediente_pro, possui_agenda_pro, ativo_pro, id_cate_fk, id_log_fk, id_perf_fk, id_end_fk) 
VALUES 
('Mariana Souza', '21987654321', 'mariana.souza@email.com', '987.654.321-00', 'Feminino', 'Psicóloga clínica', 'Seg-Sáb: 09h - 20h', TRUE, TRUE, 2, 2, 3, 4);

INSERT INTO profissional (nome_pro, celular_pro, email_pro, cpf_pro, sexo_pro, observacoes_pro, expediente_pro, possui_agenda_pro, ativo_pro, id_cate_fk, id_log_fk, id_perf_fk, id_end_fk) 
VALUES 
('João Mendes', '31987654321', 'joao.mendes@email.com', '456.789.123-00', 'Masculino', 'Personal Trainer', 'Seg-Dom: 06h - 22h', TRUE, TRUE, 3, 3, 1, 5);

create table servico (
    id_serv int primary key auto_increment,
    nome_serv varchar(200),
    descricao_serv varchar(300),
    valor_serv float,
    duracao_serv time,
    comissao_serv float,
    id_cate_fk int,
    foreign key (id_cate_fk) references categoria(id_cate)
);

    select * from servico;
    
    INSERT INTO servico (nome_serv, descricao_serv, valor_serv, duracao_serv, comissao_serv, id_cate_fk) 
VALUES 
('Consulta Psicológica', 'Atendimento psicológico individual', 150.00, '01:00:00', 20.00, 2);

INSERT INTO servico (nome_serv, descricao_serv, valor_serv, duracao_serv, comissao_serv, id_cate_fk) 
VALUES 
('Treinamento Personalizado', 'Sessão de treino com acompanhamento de personal trainer', 100.00, '01:30:00', 15.00, 3);

INSERT INTO servico (nome_serv, descricao_serv, valor_serv, duracao_serv, comissao_serv, id_cate_fk) 
VALUES 
('Sessão de Fisioterapia', 'Reabilitação física com fisioterapeuta especializado', 120.00, '00:45:00', 18.00, 1);

create table orcamento (
    id_orca int primary key auto_increment,
    descricao_orca varchar(300),
    data_orca date,
    forma_pagamento_orca varchar(45),
    valor_orca float,
    id_serv_fk int,
    foreign key (id_serv_fk) references servico(id_serv)
);

    select * from orcamento;
    
INSERT INTO orcamento (descricao_orca, data_orca, forma_pagamento_orca, valor_orca, id_serv_fk) 
VALUES 
('Orçamento para consulta psicológica inicial', '2025-03-10', 'Cartão de Crédito', 150.00, 1);

INSERT INTO orcamento (descricao_orca, data_orca, forma_pagamento_orca, valor_orca, id_serv_fk) 
VALUES 
('Orçamento para pacote de treinamento mensal', '2025-03-15', 'Pix', 400.00, 2);

INSERT INTO orcamento (descricao_orca, data_orca, forma_pagamento_orca, valor_orca, id_serv_fk) 
VALUES 
('Orçamento para 5 sessões de fisioterapia', '2025-03-20', 'Dinheiro', 600.00, 3);

create table servico_pacote (
	id_serv_pac int primary key auto_increment,
     id_serv_fk int,
	id_pac_fk int,
	foreign key (id_serv_fk) references servico(id_serv),
    foreign key (id_pac_fk) references pacote(id_pac)
);

INSERT INTO servico_pacote (id_serv_fk, id_pac_fk) 
VALUES 
(1, 1);

INSERT INTO servico_pacote (id_serv_fk, id_pac_fk) 
VALUES 
(2, 2);

INSERT INTO servico_pacote (id_serv_fk, id_pac_fk) 
VALUES 
(3, 3);

create table expediente (
    id_exp int primary key auto_increment,
    nome_exp varchar(100),
    dia_semana varchar(100),
    hora_entrada_exp time,
    hora_saida_exp time,
    almoco_inicio_exp time,
    almoco_fim_exp time,
    intervalo_almoco_exp bool,
    id_pro_fk int,
    foreign key (id_pro_fk) references profissional(id_pro)
);

    select * from expediente;
    
INSERT INTO expediente (nome_exp, dia_semana, hora_entrada_exp, hora_saida_exp, almoco_inicio_exp, almoco_fim_exp, intervalo_almoco_exp, id_pro_fk) 
VALUES 
('Expediente Psicóloga', 'Segunda-feira', '08:00:00', '18:00:00', '12:00:00', '13:00:00', TRUE, 1);

INSERT INTO expediente (nome_exp, dia_semana, hora_entrada_exp, hora_saida_exp, almoco_inicio_exp, almoco_fim_exp, intervalo_almoco_exp, id_pro_fk) 
VALUES 
('Expediente Personal Trainer', 'Terça-feira', '06:30:00', '20:00:00', '12:30:00', '13:30:00', TRUE, 2);

INSERT INTO expediente (nome_exp, dia_semana, hora_entrada_exp, hora_saida_exp, almoco_inicio_exp, almoco_fim_exp, intervalo_almoco_exp, id_pro_fk) 
VALUES 
('Expediente Fisioterapeuta', 'Quarta-feira', '07:00:00', '19:00:00', '12:00:00', '13:00:00', TRUE, 3);

create table bloqueio (
    id_blo int primary key auto_increment,
    profissional_blo int,
    data_inicio_blo date,
    data_fim_blo date,
    hora_fim_blo time,
    hora_inicio_blo time,
    motivo_bloqueio_blo varchar(100),
   dia_inteiro_blo bool
);

    select * from bloqueio;
    
INSERT INTO bloqueio (profissional_blo, data_inicio_blo, data_fim_blo, hora_inicio_blo, hora_fim_blo, motivo_bloqueio_blo, dia_inteiro_blo) 
VALUES 
(1, '2025-04-10', '2025-04-10', '08:00:00', '12:00:00', 'Consulta médica', FALSE);

INSERT INTO bloqueio (profissional_blo, data_inicio_blo, data_fim_blo, hora_inicio_blo, hora_fim_blo, motivo_bloqueio_blo, dia_inteiro_blo) 
VALUES 
(2, '2025-05-15', '2025-05-15', '14:00:00', '18:00:00', 'Compromisso pessoal', FALSE);

INSERT INTO bloqueio (profissional_blo, data_inicio_blo, data_fim_blo, hora_inicio_blo, hora_fim_blo, motivo_bloqueio_blo, dia_inteiro_blo) 
VALUES 
(3, '2025-06-01', '2025-06-01', NULL, NULL, 'Feriado', TRUE);

create table bloqueio_profissional (
	id_blo_pro int primary key auto_increment,
	id_blo_fk int,
    id_pro_fk int,
    foreign key (id_blo_fk) references bloqueio(id_blo),
    foreign key (id_pro_fk) references profissional(id_pro)
);

INSERT INTO bloqueio_profissional (id_blo_fk, id_pro_fk) 
VALUES 
(1, 1);

INSERT INTO bloqueio_profissional (id_blo_fk, id_pro_fk) 
VALUES 
(2, 2);

INSERT INTO bloqueio_profissional (id_blo_fk, id_pro_fk) 
VALUES 
(3, 3);

create table profissional_categoria (
	id_pro_cate int primary key auto_increment,
	id_pro_fk int,
    id_cate_fk int,
    foreign key (id_pro_fk) references profissional(id_pro),
    foreign key (id_cate_fk) references categoria(id_cate)
);

INSERT INTO profissional_categoria (id_pro_fk, id_cate_fk) 
VALUES 
(1, 1);

INSERT INTO profissional_categoria (id_pro_fk, id_cate_fk) 
VALUES 
(2, 2);

INSERT INTO profissional_categoria (id_pro_fk, id_cate_fk) 
VALUES 
(3, 3);

create table agenda (
    id_agend int primary key auto_increment,
    data_agend date,
    telefone_agend varchar(30),
    nome_cliente_agend varchar(100),
    observacoes_agend varchar(300),
    responsavel_agend varchar(100),
    hora_agend time,
    tempo_atendimento_agend time,
    servico_agend varchar(300),
    id_pro_fk int,
    id_cli_fk int,
    foreign key (id_pro_fk) references profissional(id_pro),
    foreign key (id_cli_fk) references cliente(id_cli)
);

    select * from agenda;
    
INSERT INTO agenda (data_agend, telefone_agend, nome_cliente_agend, observacoes_agend, responsavel_agend, hora_agend, tempo_atendimento_agend, servico_agend, id_pro_fk, id_cli_fk) 
VALUES 
('2025-03-10', '11987654321', 'Carlos Silva', 'Cliente novo, primeira consulta', 'Mariana Souza', '08:00:00', '01:00:00', 'Consulta psicológica', 1, 1);

INSERT INTO agenda (data_agend, telefone_agend, nome_cliente_agend, observacoes_agend, responsavel_agend, hora_agend, tempo_atendimento_agend, servico_agend, id_pro_fk, id_cli_fk) 
VALUES 
('2025-03-15', '21987654321', 'Ana Costa', 'Sessão de acompanhamento', 'João Mendes', '09:30:00', '01:30:00', 'Treinamento personalizado', 2, 2);

INSERT INTO agenda (data_agend, telefone_agend, nome_cliente_agend, observacoes_agend, responsavel_agend, hora_agend, tempo_atendimento_agend, servico_agend, id_pro_fk, id_cli_fk) 
VALUES 
('2025-03-20', '31987654321', 'Lucas Oliveira', 'Reabilitação física pós-cirurgia', 'Carlos Silva', '14:00:00', '00:45:00', 'Sessão de fisioterapia', 3, 3);

create table agenda_servico (
	id_agend_serv int primary key auto_increment,
	id_agend_fk int,
    id_serv_fk int,
    foreign key (id_agend_fk) references agenda(id_agend),
    foreign key (id_serv_fk) references servico(id_serv)
);

INSERT INTO agenda_servico (id_agend_fk, id_serv_fk) VALUES (1, 3);
INSERT INTO agenda_servico (id_agend_fk, id_serv_fk) VALUES (2, 5);
INSERT INTO agenda_servico (id_agend_fk, id_serv_fk) VALUES (3, 2);


create table pagamento (
    id_pag int primary key auto_increment,
    data_pag date,
    valor_pag float,
    desconto_pag float,
    forma_pagamento_pag varchar(45),
    id_caix_fk int,
    id_serv_fk int,
    id_orca_fk int,
    id_cli_fk int,
    foreign key (id_caix_fk) references caixa(id_caix),
    foreign key (id_serv_fk) references servico(id_serv),
    foreign key (id_orca_fk) references orcamento(id_orca),
    foreign key (id_cli_fk) references cliente(id_cli)
);

    select * from pagamento;

    INSERT INTO pagamento (data_pag, valor_pag, desconto_pag, forma_pagamento_pag, id_caix_fk, id_serv_fk, id_orca_fk, id_cli_fk) 
VALUES ('2025-02-15', 150.00, 10.00, 'Cartão de Crédito', 1, 2, 1, 3);

INSERT INTO pagamento (data_pag, valor_pag, desconto_pag, forma_pagamento_pag, id_caix_fk, id_serv_fk, id_orca_fk, id_cli_fk) 
VALUES ('2025-02-16', 200.00, 15.00, 'Pix', 2, 4, 2, 1);

INSERT INTO pagamento (data_pag, valor_pag, desconto_pag, forma_pagamento_pag, id_caix_fk, id_serv_fk, id_orca_fk, id_cli_fk) 
VALUES ('2025-02-17', 180.00, 5.00, 'Dinheiro', 3, 1, 3, 2);


create table anamnese_corporal (
    id_anamcorp int primary key auto_increment,
    depilacao_anamcorp bool,
    alergia_anamcorp bool,
    tipo_alergia_anamcorp varchar(45),
    problema_pele_anamcorp bool,
    tratamento_dermatologico_anamcorp bool,
    gestante_anamcorp bool,
    tipo_pele_anamcorp varchar(45),
    vasos_varicosos_anamcorp bool,
    metodos_utilizados_anamcorp varchar(45),
    areas_anamcorp varchar(200)
);
select * from anamnese_corporal;

INSERT INTO anamnese_corporal (depilacao_anamcorp, alergia_anamcorp, tipo_alergia_anamcorp, problema_pele_anamcorp, tratamento_dermatologico_anamcorp, gestante_anamcorp, tipo_pele_anamcorp, vasos_varicosos_anamcorp, metodos_utilizados_anamcorp, areas_anamcorp) 
VALUES (TRUE, FALSE, '', TRUE, FALSE, FALSE, 'Oleosa', TRUE, 'Cera Quente', 'Pernas, Axilas');

INSERT INTO anamnese_corporal (depilacao_anamcorp, alergia_anamcorp, tipo_alergia_anamcorp, problema_pele_anamcorp, tratamento_dermatologico_anamcorp, gestante_anamcorp, tipo_pele_anamcorp, vasos_varicosos_anamcorp, metodos_utilizados_anamcorp, areas_anamcorp) 
VALUES (FALSE, TRUE, 'Níquel', FALSE, TRUE, FALSE, 'Mista', FALSE, 'Lâmina', 'Rosto, Braços');

INSERT INTO anamnese_corporal (depilacao_anamcorp, alergia_anamcorp, tipo_alergia_anamcorp, problema_pele_anamcorp, tratamento_dermatologico_anamcorp, gestante_anamcorp, tipo_pele_anamcorp, vasos_varicosos_anamcorp, metodos_utilizados_anamcorp, areas_anamcorp) 
VALUES (TRUE, TRUE, 'Pólen', TRUE, TRUE, TRUE, 'Seca', TRUE, 'Laser', 'Pernas, Virilha');

create table Cliente_Anamnesecorporal (
	id_cli_anamcorp int primary key auto_increment,
	id_cli_fk int,
    id_anamcorp_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_anamcorp_fk) references anamnese_corporal(id_anamcorp)
);

INSERT INTO Cliente_Anamnesecorporal (id_cli_fk, id_anamcorp_fk) VALUES (1, 2);
INSERT INTO Cliente_Anamnesecorporal (id_cli_fk, id_anamcorp_fk) VALUES (2, 3);
INSERT INTO Cliente_Anamnesecorporal (id_cli_fk, id_anamcorp_fk) VALUES (3, 1);

create table anamnese_facial (
    id_anamfac int primary key auto_increment,
    gestante_anamfac bool,
    quedadecabelo_anamfac bool,
    alergia_anamfac bool,
    tipo_pele_anamfac varchar(45),
    medicacao_anamfac varchar(45)
);

select * from anamnese_facial;

INSERT INTO anamnese_facial (gestante_anamfac, quedadecabelo_anamfac, alergia_anamfac, tipo_pele_anamfac, medicacao_anamfac) 
VALUES (FALSE, TRUE, TRUE, 'Mista', 'Antialérgico');

INSERT INTO anamnese_facial (gestante_anamfac, quedadecabelo_anamfac, alergia_anamfac, tipo_pele_anamfac, medicacao_anamfac) 
VALUES (FALSE, FALSE, FALSE, 'Oleosa', 'Nenhuma');

INSERT INTO anamnese_facial (gestante_anamfac, quedadecabelo_anamfac, alergia_anamfac, tipo_pele_anamfac, medicacao_anamfac) 
VALUES (TRUE, TRUE, TRUE, 'Seca', 'Vitamina D');


create table Cliente_Anamnesefacial (
	id_cli_anamfac int primary key auto_increment,
	id_cli_fk int,
    id_anamfac_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_anamfac_fk) references anamnese_facial(id_anamfac)
);

INSERT INTO Cliente_Anamnesefacial (id_cli_fk, id_anamfac_fk) VALUES (1, 3);
INSERT INTO Cliente_Anamnesefacial (id_cli_fk, id_anamfac_fk) VALUES (2, 1);
INSERT INTO Cliente_Anamnesefacial (id_cli_fk, id_anamfac_fk) VALUES (3, 2);

create table anamnese_capilar (
    id_anamcap int primary key auto_increment,
    tipo_cabelo_anamcap varchar(15),
    caracteristica_anamcap varchar(45),
    comprimento_anamcap varchar(45),
    pigmentacao_anamcap varchar(45),
    elasticidade_anamcap varchar(45),
    expessura_anamcap varchar(45),
    volume_anamcap varchar(45),
    resistencia_anamcap varchar(90),
    condicao_anamcap varchar(45),
    observacoes_anamcap varchar(100),
    atendentes_alergicos_anamcap varchar(45)
);

select * from anamnese_capilar;


INSERT INTO anamnese_capilar (tipo_cabelo_anamcap, caracteristica_anamcap, comprimento_anamcap, pigmentacao_anamcap, elasticidade_anamcap, expessura_anamcap, volume_anamcap, resistencia_anamcap, condicao_anamcap, observacoes_anamcap, atendentes_alergicos_anamcap) 
VALUES ('Liso', 'Brilhante', 'Médio', 'Natural', 'Alta', 'Fina', 'Médio', 'Boa resistência', 'Saudável', 'Nenhuma observação', 'Nenhum');

INSERT INTO anamnese_capilar (tipo_cabelo_anamcap, caracteristica_anamcap, comprimento_anamcap, pigmentacao_anamcap, elasticidade_anamcap, expessura_anamcap, volume_anamcap, resistencia_anamcap, condicao_anamcap, observacoes_anamcap, atendentes_alergicos_anamcap) 
VALUES ('Cacheado', 'Seco', 'Longo', 'Tingido', 'Média', 'Grossa', 'Alto', 'Média resistência', 'Quebradiço', 'Pontas duplas visíveis', 'Nenhum');

INSERT INTO anamnese_capilar (tipo_cabelo_anamcap, caracteristica_anamcap, comprimento_anamcap, pigmentacao_anamcap, elasticidade_anamcap, expessura_anamcap, volume_anamcap, resistencia_anamcap, condicao_anamcap, observacoes_anamcap, atendentes_alergicos_anamcap) 
VALUES ('Ondulado', 'Oleoso', 'Curto', 'Natural', 'Baixa', 'Média', 'Baixo', 'Baixa resistência', 'Oleoso', 'Caspa leve', 'Alergia a tintura');



create table Cliente_Anamnesecapilar(
	id_cli_anamcap int primary key auto_increment,
	id_cli_fk int,
    id_anamcap_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_anamcap_fk) references anamnese_capilar(id_anamcap)
);

INSERT INTO Cliente_Anamnesecapilar (id_cli_fk, id_anamcap_fk) VALUES (1, 2);
INSERT INTO Cliente_Anamnesecapilar (id_cli_fk, id_anamcap_fk) VALUES (2, 3);
INSERT INTO Cliente_Anamnesecapilar (id_cli_fk, id_anamcap_fk) VALUES (3, 1);




create table anamnese_manicure_pedicure (
    id_anamncure int primary key auto_increment,
    frequencia_anamncure varchar(45),
    retiracuticula_anamncure bool,
    roeunhas_anamncure bool,
    alergia_anamncure bool,
    tipoalergia_anamncure varchar(45),
    formato_unha_anamncure varchar(45),
    tonalidade_anamncure bool,
    unhaencravada_anamncure bool,
    micose_anamncure bool,
    coresmalte_anamncure varchar(45)
);

select * from anamnese_manicure_pedicure;


INSERT INTO anamnese_manicure_pedicure (frequencia_anamncure, retiracuticula_anamncure, roeunhas_anamncure, alergia_anamncure, tipoalergia_anamncure, formato_unha_anamncure, tonalidade_anamncure, unhaencravada_anamncure, micose_anamncure, coresmalte_anamncure) 
VALUES ('Semanal', TRUE, FALSE, TRUE, 'Formol', 'Quadrado', TRUE, FALSE, FALSE, 'Vermelho');

INSERT INTO anamnese_manicure_pedicure (frequencia_anamncure, retiracuticula_anamncure, roeunhas_anamncure, alergia_anamncure, tipoalergia_anamncure, formato_unha_anamncure, tonalidade_anamncure, unhaencravada_anamncure, micose_anamncure, coresmalte_anamncure) 
VALUES ('Quinzenal', FALSE, TRUE, FALSE, '', 'Redondo', FALSE, TRUE, FALSE, 'Nude');

INSERT INTO anamnese_manicure_pedicure (frequencia_anamncure, retiracuticula_anamncure, roeunhas_anamncure, alergia_anamncure, tipoalergia_anamncure, formato_unha_anamncure, tonalidade_anamncure, unhaencravada_anamncure, micose_anamncure, coresmalte_anamncure) 
VALUES ('Mensal', TRUE, FALSE, TRUE, 'Acrilato', 'Oval', TRUE, FALSE, TRUE, 'Francesinha');



create table Cliente_Anamnesemanicurepedicure (
	id_cli_anamncure int primary key auto_increment,
	id_cli_fk int,
    id_anamncure_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_anamncure_fk) references anamnese_manicure_pedicure(id_anamncure)
);

INSERT INTO Cliente_Anamnesemanicurepedicure (id_cli_fk, id_anamncure_fk) VALUES (1, 3);
INSERT INTO Cliente_Anamnesemanicurepedicure (id_cli_fk, id_anamncure_fk) VALUES (2, 1);
INSERT INTO Cliente_Anamnesemanicurepedicure (id_cli_fk, id_anamncure_fk) VALUES (3, 2);

