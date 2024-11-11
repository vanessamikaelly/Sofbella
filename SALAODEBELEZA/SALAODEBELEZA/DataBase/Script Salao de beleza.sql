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

create table login (
    id_log int primary key auto_increment,
    email_log varchar(100) not null,
    senha_log varchar(100) not null
);
INSERT INTO login (email_log, senha_log)
VALUES
    ('usuario@exemplo.com', 'senha123'),
    ('admin@exemplo.com', 'admin123');


create table fornecedor (
    id_forn int primary key auto_increment,
    nome_forn varchar(300) not null,
    razao_social_forn varchar(100),
    cnpj_forn varchar(45) not null,
    tel_forn varchar(45),
    site_forn varchar(45)
);

create table cliente (
    id_cli int primary key auto_increment,
    nome_cli varchar(100) not null,
    email_cli varchar(100),
    tel_cli varchar(20),
    cpf_cli varchar(45) not null,
    sexo_cli varchar(45),
    data_nasc_cli date
);

create table caixa (
    id_caix int primary key auto_increment,
    usuario_caix varchar(100),
    data_inicio_caix date,
    valor_inicial_caix float,
    entrada_caix float,
    saida_caix float,
    saldo_final_caix float
);

create table estoque (
    id_est int primary key auto_increment,
    nomeprod_est varchar(100) not null,
   estoque_atual_est float,
   entrada_est float,
    preco_compra_est float,
    preco_venda_est float,
    fornecedor_est int
);

create table baixa_uso_interno (
	id_baixa int primary key auto_increment,
    nome_baixa varchar(100),
    estoqueatual_baixa int,
    baixarestoque_baixa int,
    descricao_baixa varchar(100),
    id_est_fk int,
    foreign key (id_est_fk) references estoque (id_est)
    );

create table pacote (
    id_pac int primary key auto_increment,
    nome_pacote_pac varchar(300) not null,
    valor_pacote_pac float not null,
    validade_pacote_pac date,
    itens_pacote_pac varchar(300)
);

create table profissional (
    id_pro int primary key auto_increment,
    nome_pro varchar(100) not null,
	celular_pro varchar(100),
    email_pro varchar(100),
    senha_pro varchar(20),
    cpf_pro varchar(45) not null,
    sexo_pro varchar(45),
    observacoes_pro varchar(45),
    expediente_pro varchar(300),
    categoria_pro varchar(50),
    perfil_acesso_pro varchar(50),
    possui_agenda_pro boolean,
    rg_pro varchar(45) not null,
    data_nasc_pro date,
    ativo_pro boolean,
    id_log_fk int,
    id_perf_fk int,
    foreign key ( id_log_fk) references login(id_log),
    foreign key (id_perf_fk) references perfil(id_perf)
);
INSERT INTO profissional (
    nome_pro, celular_pro, email_pro, senha_pro, cpf_pro, sexo_pro, observacoes_pro, 
    expediente_pro, categoria_pro, perfil_acesso_pro, possui_agenda_pro, rg_pro, 
    data_nasc_pro, ativo_pro, id_log_fk, id_perf_fk
) 
VALUES (
    'João Silva', '12345-6789', 'joao.silva@email.com', 'senha123', '123.456.789-00', 
    'Masculino', 'Nenhuma observação', 'Segunda a Sexta, das 9h às 18h', 'Estagiário', 
    'Administrador', true, '12.345.678-9', '1990-05-15', true, 1, 1
);
select * from profissional;

create table endereco (
    id_end int primary key auto_increment,
    rua_end varchar(45),
    bairro_end varchar(45),
    numero_end varchar(10),
    cidade_end varchar(45),
    estado_end varchar(45),
    pais_end varchar(45),
    cep_end varchar(45),
    id_cli_fk int,
    id_pro_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_pro_fk) references profissional(id_pro)
);

create table categoria (
    id_cate int primary key auto_increment,
    nome_cate varchar(100),
    tipo_cate varchar(45),
    descricao_cate varchar(45)
);

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
    id_forn_fk int,
    id_est_fk int,
    foreign key (id_cate_fk) references categoria(id_cate),
    foreign key (id_forn_fk) references fornecedor(id_forn),
    foreign key (id_est_fk) references estoque(id_est)
);

create table orcamento (
    id_orca int primary key auto_increment,
    descricao_orca varchar(300),
    data_orca date,
    forma_pagamento_orca varchar(45),
    valor_orca float,
    id_cli_fk int,
    foreign key (id_cli_fk) references cliente(id_cli)
);

create table servico (
    id_serv int primary key auto_increment,
    nome_serv varchar(200),
    descricao_serv varchar(300),
    valor_serv float,
    duracao_serv time,
    comissao_serv float,
    id_cate_fk int,
    id_orca_fk int,
    foreign key (id_cate_fk) references categoria(id_cate),
    foreign key (id_orca_fk) references orcamento(id_orca)
);

create table servico_pacote (
	id_serv_pac int primary key auto_increment,
     id_serv_fk int,
	id_pac_fk int,
	foreign key (id_serv_fk) references servico(id_serv),
    foreign key (id_pac_fk) references pacote(id_pac)
);

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

	

create table bloqueio_profissional (
	id_blo_pro int primary key auto_increment,
	id_blo_fk int,
    id_pro_fk int,
    foreign key (id_blo_fk) references bloqueio(id_blo),
    foreign key (id_pro_fk) references profissional(id_pro)
);

create table profissional_categoria (
	id_pro_cate int primary key auto_increment,
	id_pro_fk int,
    id_cate_fk int,
    foreign key (id_pro_fk) references profissional(id_pro),
    foreign key (id_cate_fk) references categoria(id_cate)
);

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

create table agenda_servico (
	id_agend_serv int primary key auto_increment,
	id_agend_fk int,
    id_serv_fk int,
    foreign key (id_agend_fk) references agenda(id_agend),
    foreign key (id_serv_fk) references servico(id_serv)
);

create table pagamento (
    id_pag int primary key,
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

create table Cliente_Anamnesecorporal (
	id_cli_anamcorp int primary key auto_increment,
	id_cli_fk int,
    id_anamcorp_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_anamcorp_fk) references anamnese_corporal(id_anamcorp)
);

create table anamnese_facial (
    id_anamfac int primary key auto_increment,
    gestante_anamfac bool,
    quedadecabelo_anamfac bool,
    alergia_anamfac bool,
    tipo_pele_anamfac varchar(45),
    medicacao_anamfac varchar(45)
);

create table Cliente_Anamnesefacial (
	id_cli_anamfac int primary key auto_increment,
	id_cli_fk int,
    id_anamfac_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_anamfac_fk) references anamnese_facial(id_anamfac)
);

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

create table Cliente_Anamnesecapilar(
	id_cli_anamcap int primary key auto_increment,
	id_cli_fk int,
    id_anamcap_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_anamcap_fk) references anamnese_capilar(id_anamcap)
);

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
create table Cliente_Anamnesemanicurepedicure (
	id_cli_anamncure int primary key auto_increment,
	id_cli_fk int,
    id_anamncure_fk int,
    foreign key (id_cli_fk) references cliente(id_cli),
    foreign key (id_anamncure_fk) references anamnese_manicure_pedicure(id_anamncure)
);

