using Godot;
using System;

public partial class Fractal : ColorRect
{
    private ShaderMaterial material;

    [Export] private SpinBox max_x;
    [Export] private SpinBox min_x;
    [Export] private SpinBox max_y;
    [Export] private SpinBox min_y;
    [Export] private SpinBox max_color;

    private bool mousePresed = false;

    private double _curMaxX = 1.0;
    private double _curMinX = -2.2;
    private double _curMaxY = 1.2;
    private double _curMinY = -1.2;

    const double minSize = 0.00003;

    public override void _Ready()
    {
        base._Ready();
        material = (ShaderMaterial)Material;

        if (max_x != null) _curMaxX = max_x.Value;
        if (min_x != null) _curMinX = min_x.Value;
        if (max_y != null) _curMaxY = max_y.Value;
        if (min_y != null) _curMinY = min_y.Value;
    }
    private void _on_max_x_changed(float value)
    {
        if (value < _curMinX)
        {
            value = (float)_curMinX;
            if (max_x != null) max_x.SetValueNoSignal(value);
        }
        _curMaxX = value;
        material.SetShaderParameter("x_max", value);
    }
    private void _on_min_x_changed(float value)
    {
        if (value > _curMaxX)
        {
            value = (float)_curMaxX;
            if (min_x != null) min_x.SetValueNoSignal(value);
        }
        _curMinX = value;
        material.SetShaderParameter("x_min", value);
    }
    private void _on_max_y_changed(float value)
    {
        if (value < _curMinY)
        {
            value = (float)_curMinY;
            if (max_y != null) max_y.SetValueNoSignal(value);
        }
        _curMaxY = value;
        material.SetShaderParameter("y_max", value);
    }
    private void _on_min_y_changed(float value)
    {
        if (value > _curMaxY)
        {
            value = (float)_curMaxY;
            if (min_y != null) min_y.SetValueNoSignal(value);
        }
        _curMinY = value;
        material.SetShaderParameter("y_min", value);
    }
    private void _on_MAXCOLOR_changed(float value)
    {
        material.SetShaderParameter("maxColor", (int)value);
    }

    private void _on_reset_pressed()
    {
        max_x.Value = 1;
        min_x.Value = -2.2;
        max_y.Value = 1.2;
        min_y.Value = -1.2;
        max_color.Value = 100;
    }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.ButtonIndex == MouseButton.WheelUp)
            {
                if (mouseEvent.Pressed) Zoom(mouseEvent.Position, 0.8);
            }
            else if (mouseEvent.ButtonIndex == MouseButton.WheelDown)
            {
                if (mouseEvent.Pressed) Zoom(mouseEvent.Position, 1.25);
            }
            else
            {
                mousePresed = mouseEvent.Pressed;
            }
        }
        else if (@event is InputEventMouseMotion motionEvent && mousePresed)
        {
            Pan(motionEvent.Relative);
        }
    }

    private void Pan(Vector2 relative)
    {
        double w = _curMaxX - _curMinX;
        double h = _curMaxY - _curMinY;

        double dx = w * (relative.X / Size.X);
        double dy = h * (relative.Y / Size.Y);

        double nextMinX = _curMinX - dx;
        double nextMaxX = _curMaxX - dx;
        double nextMinY = _curMinY - dy;
        double nextMaxY = _curMaxY - dy;

        if (nextMaxX > 10)
        {
            nextMaxX = 10;
            nextMinX = 10 - w;
        }
        else if (nextMinX < -10)
        {
            nextMinX = -10;
            nextMaxX = -10 + w;
        }

        if (nextMaxY > 10)
        {
            nextMaxY = 10;
            nextMinY = 10 - h;
        }
        else if (nextMinY < -10)
        {
            nextMinY = -10;
            nextMaxY = -10 + h;
        }

        _curMinX = nextMinX;
        _curMaxX = nextMaxX;
        _curMinY = nextMinY;
        _curMaxY = nextMaxY;

        if (min_x != null) min_x.SetValueNoSignal(_curMinX);
        if (max_x != null) max_x.SetValueNoSignal(_curMaxX);
        if (min_y != null) min_y.SetValueNoSignal(_curMinY);
        if (max_y != null) max_y.SetValueNoSignal(_curMaxY);

        material.SetShaderParameter("x_min", (float)_curMinX);
        material.SetShaderParameter("x_max", (float)_curMaxX);
        material.SetShaderParameter("y_min", (float)_curMinY);
        material.SetShaderParameter("y_max", (float)_curMaxY);
    }

    private void Zoom(Vector2 mousePos, double factor)
    {
        double w = _curMaxX - _curMinX;
        double h = _curMaxY - _curMinY;

        double relativeX = mousePos.X / Size.X;
        double relativeY = mousePos.Y / Size.Y;

        double fractalX = _curMinX + w * relativeX;
        double fractalY = _curMinY + h * relativeY;

        double newW = w * factor;
        double newH = h * factor;
        if (newW < minSize || newH < minSize || newH > 10 || newW > 10) return;

        _curMinX = fractalX - newW * relativeX;
        _curMaxX = _curMinX + newW;
        _curMinY = fractalY - newH * relativeY;
        _curMaxY = _curMinY + newH;

        if (min_x != null) min_x.SetValueNoSignal(_curMinX);
        if (max_x != null) max_x.SetValueNoSignal(_curMaxX);
        if (min_y != null) min_y.SetValueNoSignal(_curMinY);
        if (max_y != null) max_y.SetValueNoSignal(_curMaxY);

        material.SetShaderParameter("x_min", (float)_curMinX);
        material.SetShaderParameter("x_max", (float)_curMaxX);
        material.SetShaderParameter("y_min", (float)_curMinY);
        material.SetShaderParameter("y_max", (float)_curMaxY);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed && keyEvent.Keycode == Key.Escape)
        {
            GetTree().Quit();
        }
    }
}
