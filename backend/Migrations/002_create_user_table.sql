CREATE TABLE IF NOT EXISTS users(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    username VARCHAR(255) NOT NULL,
    hashed_password BYTEA NOT NULL,
    user_type VARCHAR(50) NOT NULL CHECK(user_type IN ('Admin', 'Barista')) 
)