CREATE TABLE IF NOT EXISTS drinks(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(255) NOT NULL,
    price DECIMAL NOT NULL,
    recipe TEXT NOT NULL,
    size VARCHAR(50) NOT NULL CHECK(size IN ('Large','Medium','Small')),
    drink_type VARCHAR(50) NOT NULL CHECK(size IN ('Hot', 'Cold'))
);