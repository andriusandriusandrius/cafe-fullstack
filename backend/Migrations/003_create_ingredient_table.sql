CREATE TABLE IF NOT EXISTS ingredients(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(255) NOT NULL,
    price DECIMAL NOT NULL,
)