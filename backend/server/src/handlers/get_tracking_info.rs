use axum::{extract::{Path, State}, http::StatusCode, Json};
use sqlx::PgPool;
use crate::{processes::fetch_tracking_info::fetch_tracking_info, tracking_info_db::TrackingInfoDB};

pub async fn get_tracking_info(
    State(pool): State<PgPool>,
    Path(tracking_id): Path<i64>
) -> Result<Json<Vec<TrackingInfoDB>>, StatusCode> {
    match fetch_tracking_info(&pool, &tracking_id).await {
        Ok(info) => Ok(Json(info)),
        Err(_) => Err(axum::http::StatusCode::NOT_FOUND),
    }
}