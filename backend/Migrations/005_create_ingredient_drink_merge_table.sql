CREATE TABLE IF NOT EXISTS drink_ingredients(
    drink_id UUID NOT NULL REFERENCES drinks(id),
    ingredient_id UUID NOT NULL REFERENCES ingredients(id) ON DELETE CASCADE,
    PRIMARY KEY (drink_id, ingredient_id)
)