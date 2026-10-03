import tkinter as tk
from PIL import Image, ImageTk

root = tk.Tk()
root.geometry("640x800")

img = Image.new("RGB", (640, 800), "black")

pixels = img.load()



def draw_line(x0, y0, x1, y1, color, pix):
    dx = x1 - x0
    dy = y1 - y0
    if abs(dx) < abs(dy):
        if dy == 0:
            if x1 < x0:
                for i in range(x0, x1-1, -1):
                    pix[i, y0] = color
            else:
                for i in range(x0, x1+1):
                    pix[i, y0] = color
            return
        a = dx / dy
        b = x0 - a * y0
        if y1<y0:
            for i in range(y0, y1-1, -1):
                pixels[int(a*i+b),i] = color
        else:
            for i in range(y0, y1+1):
                pixels[int(a*i+b),i] = color
    else:
        if dx == 0:
            if y1 < y0:
                for i in range(y0, y1-1, -1):
                    pix[x0, i] = color
            else:
                for i in range(y0, y1+1):
                    pix[x0, i] = color
            return
        a = dy / dx
        b = y0 - a * x0
        if x1<x0:
            for i in range(x0, x1-1, -1):
                pixels[i,int(a*i+b)] = color
        else:
            for i in range(x0, x1+1):
                pixels[i,int(a*i+b)] = color

def draw_8_pixels(x0,y0,x,y,color,pix):
    pix[x0+x,y0+y] = color
    pix[x0-x,y0+y] = color
    pix[x0+x,y0-y] = color
    pix[x0-x,y0-y] = color
    pix[x0+y,y0+x] = color
    pix[x0-y,y0+x] = color
    pix[x0+y,y0-x] = color
    pix[x0-y,y0-x] = color

def draw_circle(x0, y0, R, color, pix):
    x=0
    y=R
    d = 3 - 2*R
    while y >= x:
        draw_8_pixels(x0, y0, x, y, color, pix)
        if d > 0:
            d = d + 4*x - 4*y + 10
            y -= 1
        else:
            d = d + 4*x + 6
        x += 1

def draw_bezier_curve(points, step, color, pix):
    if step <= 1:
        step = 0.000001
        
    t = 0.0
    while t <= 1.0 + step / 2:
        current_points = list(points)
        
        while len(current_points) > 1:
            next_points = []
            for i in range(len(current_points) - 1):
                x = current_points[i][0] + (current_points[i+1][0] - current_points[i][0]) * t
                y = current_points[i][1] + (current_points[i+1][1] - current_points[i][1]) * t
                next_points.append((x, y))
            current_points = next_points
            
        if current_points:
            px, py = int(round(current_points[0][0])), int(round(current_points[0][1]))
            if 0 <= px < 640 and 0 <= py < 800:
                pix[px, py] = color
                
        t += step

def draw_polygon(points,color,pix):
    ymin = min(p[1] for p in points)
    ymax = max(p[1] for p in points)

    for y in range(ymin, ymax+1):
        intersections = []
        
        for i in range(len(points)):
            p1 = points[i]
            p2 = points[(i+1) % len(points)]
            
            if min(p1[1], p2[1]) <= y <= max(p1[1], p2[1]):
                
                if p1[1] == p2[1]:
                    continue
                    
                if p1[1] == y:
                    intersections.append(p1[0])
                elif p2[1] == y:
                    intersections.append(p2[0])
                else:
                    
                    x = p1[0] + (y - p1[1]) * (p2[0] - p1[0]) / (p2[1] - p1[1])
                    intersections.append(x)
                    
        intersections.sort()
        
        for i in range(0, len(intersections), 2):
            if i + 1 < len(intersections):
                x1 = int(intersections[i])
                x2 = int(intersections[i+1])
                draw_line(x1, y, x2, y, color, pix)

def fill_texture(x0, y0, texture, line_color, pix, width=640, height=800):
    if not (0 <= x0 < width and 0 <= y0 < height):
        return

    texture_pixels = texture.load()
    texture_width = texture.width
    texture_height = texture.height

    stack = [(x0, y0)]

    filled_pix = set()

    while stack:
        x, y = stack.pop()
        
        for dx, dy in [(1, 0), (-1, 0), (0, 1), (0, -1)]:
            nx, ny = x + dx, y + dy
            if 0 <= nx < width and 0 <= ny < height:
                if (nx, ny) not in filled_pix and pix[nx, ny] != line_color:
                    pix[nx, ny] = texture_pixels[nx%texture_width,ny%texture_height]
                    filled_pix.add((nx, ny))
                    stack.append((nx, ny))

def fill(x0, y0, color, line_color, pix, width=640, height=800):
    if not (0 <= x0 < width and 0 <= y0 < height):
        return


    stack = [(x0, y0)]

    while stack:
        x, y = stack.pop()
        
        for dx, dy in [(1, 0), (-1, 0), (0, 1), (0, -1)]:
            nx, ny = x + dx, y + dy
            if 0 <= nx < width and 0 <= ny < height:
                if pix[nx, ny] != color and pix[nx, ny] != line_color:
                    pix[nx, ny] = color
                    stack.append((nx, ny))

brick = Image.open("brick.png")

draw_line(240, 650, 240, 350, (255, 255, 255), pixels)
draw_line(400, 650, 400, 350, (255, 255, 255), pixels)
draw_line(240, 350, 400, 350, (255, 255, 255), pixels)
draw_line(240, 650, 400, 650, (255, 255, 255), pixels)

fill(320, 500, (255, 255, 255), (255, 255, 255), pixels)

fill_texture(0, 0, brick, (255, 255, 255), pixels)

draw_line(320, 350, 320, 320, (255, 255, 255), pixels)

draw_bezier_curve([(320, 320), (290, 300), (310, 240), (320, 200)], 0.01, (255, 255, 0), pixels)
draw_bezier_curve([(320, 320), (350, 300), (330, 240), (320, 200)], 0.01, (255, 255, 0), pixels)

fill(320, 260, (255, 165, 0), (255, 255, 0), pixels)

draw_circle(320, 260, 75, (255, 165, 0), pixels)

draw_polygon([(100, 799), (540, 799), (475, 650), (165, 650)], (128, 128, 128), pixels)

tk_img = ImageTk.PhotoImage(img)
canvas = tk.Canvas(root, width=640, height=800)
canvas.create_image(0, 0, anchor="nw", image=tk_img)
canvas.pack()

root.mainloop()