extends ColorRect


@onready var scroll_line = $line_wrapper/scroll_line;
@onready var card_scale = $line_wrapper/scroll_line/card_menu;

func _ready():
	pass;


func _on_left_pressed():
	scroll_line.position.x -= card_scale.size.x;


func _on_right_pressed():
	scroll_line.position.x += card_scale.size.x;
