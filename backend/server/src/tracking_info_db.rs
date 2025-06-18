use serde::{Deserialize, Serialize};
use sqlx::prelude::FromRow;

#[derive(Serialize, Deserialize, FromRow)]
pub struct TrackingInfoDB {
    pub tracking_id: i64,
    pub carrier: String,
    pub delivery_date: String,
    pub status: String,
    pub city: String,
    pub state: String,
    pub length: i64,
    pub width: i64,
    pub height: i64,
    pub weight: f64,
}