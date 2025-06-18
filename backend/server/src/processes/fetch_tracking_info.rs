use sqlx::PgPool;
use crate::tracking_info_db::TrackingInfoDB;

pub async fn fetch_tracking_info(pool: &PgPool, tracking_info: &i64) -> sqlx::Result<Vec<TrackingInfoDB>> {
    let query = "SELECT * FROM tracking_info WHERE tracking_id = $1";

    let tracking_records: Vec<TrackingInfoDB> = sqlx::query_as(query)
        .bind(tracking_info)
        .fetch_all(pool)
        .await?;

    Ok(tracking_records)
}