CREATE TABLE users (
	user_id serial primary key,
	first_name varchar(200) not null,
	last_name varchar(200) not null,
	books_checked int,
	user_password varchar not null
)

CREATE TABLE books (
	book_id serial primary key,
	title varchar not null,
	author varchar not null,
	ISBN int unique,
	copies int
)

CREATE TABLE checked_out (
	user_id serial not null,
	book_id serial not null,
	due_date date not null
)