extends Camera2D

var min_zoom = 0.5; var max_zoom = 2.0;
var zoom_factor = 0.1; var zoom_duration = 0.2;

var _zoom_level = 1.0;

func set_zoom_level(value: float) -> void:
	var tween = get_tree().create_tween();
	
	_zoom_level = clamp(value, min_zoom, max_zoom)

	tween.tween_property(
		self,
		"zoom",
		Vector2(_zoom_level, _zoom_level), zoom_duration
	)
	await tween.finished;

func _unhandled_input(event):
	if event.is_action_pressed("camera_zoom_in"):
		set_zoom_level(_zoom_level - zoom_factor)
	if event.is_action_pressed("camera_zoom_out"):
		set_zoom_level(_zoom_level + zoom_factor)
